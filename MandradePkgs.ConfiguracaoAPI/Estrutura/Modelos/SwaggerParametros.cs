namespace MandradePkgs.ConfiguracaoAPI.Estrutura.Modelos
{
    public class SwaggerParametros
    {
        public SwaggerParametros(string nomeAPI, string versao)
        {
            NomeAPI = nomeAPI;
            Versao = versao.ToLower();
        }
        
        public string NomeAPI { get; set; }
        public string Versao { get; set; }
    }
}