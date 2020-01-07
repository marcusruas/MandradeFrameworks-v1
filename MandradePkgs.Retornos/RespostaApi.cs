using MandradePkgs.Mensagens;
using System.Collections.Generic;

namespace MandradePkgs.Retornos
{
    public class RespostaApi<T>
    {
        public RespostaApi(bool sucesso, T dados, MensagensApi mensagens) {
            Sucesso = sucesso;
            Dados = dados;
            Mensagens = mensagens.ObterMensagens();
        }

        public RespostaApi(T dados, MensagensApi mensagens) {
            Sucesso = true;
            Dados = dados;
            Mensagens = mensagens.ObterMensagens();
        }

        public bool Sucesso { get; }
        public T Dados { get; }
        public List<Mensagem> Mensagens { get; }
    }

    public class RespostaApi
    {
        public RespostaApi(MensagensApi mensagens) {
            Sucesso = true;
            Dados = "Método executado com sucesso";
            Mensagens = mensagens.ObterMensagens();
        }

        public RespostaApi(bool sucesso, MensagensApi mensagens) {
            Sucesso = sucesso;
            Dados = null;
            Mensagens = mensagens.ObterMensagens();
        }

        public bool Sucesso { get; }
        public string Dados { get; }
        public List<Mensagem> Mensagens { get; }
    }
}