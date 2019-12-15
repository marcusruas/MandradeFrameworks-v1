using System;
using System.Data;

namespace MandradePkgs.Conexoes
{
    public interface IConexaoSQL
    {
        string ObterConsultaArquivoSQL(Type classeExecutora, string nomeArquivo);
        string ObterConnectionString(string nomeBanco);
        IDbConnection CriarNovaConexao(string nomeBanco);
        (string, IDbConnection) ObterComandoSQLParaBanco(Type classeExecutora, string nomeArquivo, string nomeBanco);
    }
}