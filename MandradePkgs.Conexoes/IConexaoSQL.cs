using System.Data;
using MandradePkgs.Conexoes.Estrutura.Model;

namespace MandradePkgs.Conexoes
{
    public interface IConexaoSQL
    {
        string ObterConteudoArquivoSQL(ClasseRepositorio classeExecutora, string nomeArquivo);
        string ObterConnectionString(string nomeBanco);
        IDbConnection CriarNovaConexao(string nomeBanco);
        (string, IDbConnection) ObterComandoSQLParaBanco(ClasseRepositorio classeExecutora, string nomeArquivo, string nomeBanco);
    }
}