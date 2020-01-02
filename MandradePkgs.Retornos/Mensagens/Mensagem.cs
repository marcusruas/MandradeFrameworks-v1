using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Mensagens
{
    public class Mensagem
    {
        public Mensagem(TipoMensagem tipo, string texto) {
            Tipo = tipo;
            Texto = texto;
        }

        public Mensagem(string texto) {
            Tipo = TipoMensagem.Informativo;
            Texto = texto;
        }

        public TipoMensagem Tipo { get; set; }
        public string Texto { get; set; }
    }
}
