namespace MandradePkgs.Mensagens
{
    public class Mensagem
    {
        public Mensagem(TipoMensagem tipo, string texto) {
            Tipo = (int)tipo;
            Texto = texto;
        }

        public Mensagem(string texto) {
            Tipo = (int)TipoMensagem.Informativo;
            Texto = texto;
        }

        public int Tipo { get; set; }
        public string Texto { get; set; }
    }
}
