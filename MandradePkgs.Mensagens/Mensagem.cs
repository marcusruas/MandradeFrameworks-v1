using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Mensagens
{
    public class Mensagem
    {
        public Mensagem(TipoMensagem tipo, string texto) {
            Tipo = tipo.ToString();
            Texto = texto;
        }

        public Mensagem(string texto) {
            Tipo = TipoMensagem.Informativo.ToString();
            Texto = texto;
        }

        public string Tipo { get; set; }
        public string Texto { get; set; }
    }
}
