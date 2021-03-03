using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using MandradePkgs.Autenticacao.Estrutura.Token;
using MandradePkgs.Conexoes;
using Microsoft.AspNetCore.Mvc.Filters;
using Dapper;

namespace MandradePkgs.Autenticacao.Estrutura.Filtros
{
    public class Autorizacao : ActionFilterAttribute
    {
        Guid permissaoEndpoint;

        public Autorizacao(string parametro)
        {
            bool guidValido = Guid.TryParse(parametro, out permissaoEndpoint);
            if (!guidValido)
                throw new ArgumentException("Permissão informada é inválida");
        }
        
        public override void OnActionExecuting(ActionExecutingContext context) {
            IConexaoSQL conexaoSQL = (IConexaoSQL)context.HttpContext.RequestServices.GetService(typeof(IConexaoSQL));
            List<Guid> permissoes = new List<Guid>();
            string token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            UsuarioToken usuario;
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Token informado é inválido");

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var dados = handler.ReadJwtToken(token).Payload;
                usuario = DecriptarUsuario(dados);
            }
            catch {
                throw new ArgumentException("Token no formato inválido.");
            }

            try {
                using (var _conn = conexaoSQL.CriarNovaConexao("SHAREDB"))
                    permissoes = _conn.Query<Guid>(ObterQuerySQL(), new { Usuario = usuario.Usuario }).ToList();
            } catch(SqlException ex) {
                throw new Exception($"Falha ao se conectar ao banco de dados, {ex.Message}");
            }

            if (!permissoes.Any(permissao => permissao == permissaoEndpoint))
                throw new Exception($"Usuário não possui permissão ao acesso {permissaoEndpoint.ToString()}");
        }

        private UsuarioToken DecriptarUsuario(JwtPayload dados) {
            var dadosUsuario = int.Parse(dados["Usuario"].ToString());
            var dadosGrupo = int.Parse(dados["Grupo"].ToString());
            var dadosPessoa = int.Parse(dados["Pessoa"].ToString());

            return new UsuarioToken(dadosUsuario, dadosGrupo, dadosPessoa);
        }

        private static string ObterQuerySQL() {
            return @"SELECT DISTINCT
                        P.PERMISSAO
                    FROM PERMISSOES P
                    LEFT JOIN PERMISSOES_USUARIOS PU ON
                        PU.PERMISSAO = P.ID_PERMISSAO
                    LEFT JOIN PERMISSOES_GRUPOS PG ON
                        PG.PERMISSAO = P.ID_PERMISSAO
                    WHERE 
                    (	
                        PU.USUARIO = @USUARIO
                        OR	PG.GRUPO = (SELECT GRUPO FROM USUARIOS WHERE ID_USUARIO = @USUARIO)
                    )
                    AND P.ATIVO = 1";
        }
    }
}