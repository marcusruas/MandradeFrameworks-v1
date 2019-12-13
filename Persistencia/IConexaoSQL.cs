using System;
using System.Data;

namespace MandradePkgs.Persistencia
{
    public interface IConexaoSQL
    {
        string ObterConsultaArquivoSQL(Type classeExecutora, string nomeArquivo);
        string ObterConnectionString(string nomeArquivo);
        IDbConnection CriarNovaConexao(string nomeBanco);
        (string, IDbConnection) ObterComandoSQLParaBanco(Type classeExecutora, string nomeArquivo, string nomeBanco);
    }
}
