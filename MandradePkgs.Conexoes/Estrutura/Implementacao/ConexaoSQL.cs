using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static MandradePkgs.Conexoes.Estrutura.Helpers.LeitorArquivos;

namespace MandradePkgs.Conexoes.Estrutura.Implementacao
{
    public class ConexaoSQL : IConexaoSQL
    {
        private Type _localConexoes;
        public ConexaoSQL(Type localConexoes) {
            _localConexoes = localConexoes;
        }

        public string ObterConsultaArquivoSQL(Type classeExecutora, string nomeArquivo) {
            return LerArquivoSQL(classeExecutora, nomeArquivo);
        }

        public (string, IDbConnection) ObterComandoSQLParaBanco(Type classeExecutora, string nomeArquivo, string nomeBanco) {
            return (
                ObterConsultaArquivoSQL(classeExecutora, nomeArquivo),
                CriarNovaConexao(nomeBanco)
            );
        }
        public IDbConnection CriarNovaConexao(string nomeBanco) {
            return new SqlConnection(BuscarConnectionString(_localConexoes, nomeBanco));
        }

        public string ObterConnectionString(string nomeBanco) {
            return BuscarConnectionString(_localConexoes, nomeBanco);
        }
    }
}
