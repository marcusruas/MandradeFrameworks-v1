﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static MandradePkgs.Persistencia.Estrutura.Helpers.LeitorArquivos;

namespace MandradePkgs.Persistencia.Estrutura.Implementacao
{
    internal class ConexaoSQL : IConexaoSQL
    {
        private Type _localConexoes;
        public ConexaoSQL(Type localConexoes) {
            _localConexoes = localConexoes;
        }

        public string ObterConsultaArquivoSQL(Type classeExecutora, string nomeArquivo) {
            return LerArquivoSQL(_localConexoes, nomeArquivo);
        }

        public IDbConnection CriarNovaConexao(string nomeBanco) {
            return new SqlConnection(BuscarConnectionString(_localConexoes, nomeBanco));
        }

        public (string, IDbConnection) ObterComandoSQLParaBanco(Type classeExecutora, string nomeArquivo, string nomeBanco) {
            return (
                ObterConsultaArquivoSQL(classeExecutora, nomeArquivo),
                CriarNovaConexao(nomeBanco)
            );
        }

        public string ObterConnectionString(string nomeBanco) {
            return BuscarConnectionString(_localConexoes, nomeBanco);
        }
    }
}
