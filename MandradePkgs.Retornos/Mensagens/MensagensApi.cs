using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MandradePkgs.Retornos.Mensagens
{
    public class MensagensApi
    {
        public MensagensApi() {
            Mensagens = new List<Mensagem>();
        }

        private List<Mensagem> Mensagens;

        public void AdicionarMensagem(string mensagem) => Mensagens.Add(new Mensagem(mensagem));
        public void AdicionarMensagem(TipoMensagem tipoMensagem, string mensagem) => Mensagens.Add(new Mensagem(tipoMensagem, mensagem));
        public bool PossuiMensagensErro() => Mensagens.Any(x => x.Tipo == TipoMensagem.Erro);
        private void LimparMensagens() => Mensagens.Clear();

        public List<Mensagem> ObterMensagens() {
            var _mensagens = new List<Mensagem>(Mensagens);
            return _mensagens;
        }
    }
}
