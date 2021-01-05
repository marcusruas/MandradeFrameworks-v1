namespace MandradePkgs.Conexoes.Estrutura.Model
{
    public abstract class ClasseRepositorio
    {
        public ClasseRepositorio(string namespaceSelecionado, string pastaPadraoArquivos)
        {
            Namespace = namespaceSelecionado;
            PastaPadraoArquivos = pastaPadraoArquivos;
        }

        public ClasseRepositorio(string namespaceSelecionado)
        {
            Namespace = namespaceSelecionado;
            PastaPadraoArquivos = "SQL";
        }

        public string Namespace { get; set; }
        public string PastaPadraoArquivos { get; set; }
    }
}