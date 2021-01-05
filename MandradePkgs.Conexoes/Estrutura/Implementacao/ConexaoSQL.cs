using System;
using System.Data;
using System.Data.SqlClient;
using MandradePkgs.Conexoes.Estrutura.Model;
using static MandradePkgs.Conexoes.Estrutura.LeitorArquivos;

namespace MandradePkgs.Conexoes.Estrutura.Implementacao
{
    public class ConexaoSQL : IConexaoSQL
    {
        private Type _localConexoes;
        public ConexaoSQL(Type localConexoes) {
            _localConexoes = localConexoes;
        }

        public IDbConnection CriarNovaConexao(string nomeBanco) =>
            new SqlConnection(BuscarConnectionString(_localConexoes, nomeBanco));

        public (string, IDbConnection) ObterComandoSQLParaBanco(ClasseRepositorio classeExecutora, string nomeArquivo, string nomeBanco) =>
        (
            ObterConteudoArquivoSQL(classeExecutora, nomeArquivo),
            CriarNovaConexao(nomeBanco)
        );

        public string ObterConnectionString(string nomeBanco) =>
            BuscarConnectionString(_localConexoes, nomeBanco);

        public string ObterConteudoArquivoSQL(ClasseRepositorio classeExecutora, string nomeArquivo) =>
            LerArquivoSQL(classeExecutora, nomeArquivo);
    }
}