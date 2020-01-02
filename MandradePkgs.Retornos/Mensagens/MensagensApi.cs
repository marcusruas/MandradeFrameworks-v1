using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Mensagens
{
    public class MensagensApi
    {
        public MensagensApi() {
            Mensagens = new List<Mensagem>();
        }

        public List<Mensagem> Mensagens { get; }

        public void AdicionarMensagem(string mensagem) => Mensagens.Add(new Mensagem(mensagem));
        public void AdicionarMensagem(TipoMensagem tipoMensagem, string mensagem) => Mensagens.Add(new Mensagem(tipoMensagem, mensagem));
    }
}
