using MandradePkgs.Mensagens;
using System.Collections.Generic;

namespace MandradePkgs.Retornos
{
    public class RespostaApi<T>
    {
        public RespostaApi(bool sucesso, T dados, List<Mensagem> mensagens) {
            Sucesso = sucesso;
            Dados = dados;
            Mensagens = mensagens;
        }

        public RespostaApi(T dados, List<Mensagem> mensagens) {
            Sucesso = true;
            Dados = dados;
            Mensagens = mensagens;
        }

        public bool Sucesso { get; }
        public T Dados { get; }
        public List<Mensagem> Mensagens { get; }
    }

    public class RespostaApi
    {
        public RespostaApi(List<Mensagem> mensagens) {
            Sucesso = true;
            Dados = "Método executado com sucesso";
            Mensagens = mensagens;
        }

        public RespostaApi(bool sucesso, List<Mensagem> mensagens) {
            Sucesso = sucesso;
            Dados = null;
            Mensagens = mensagens;
        }

        public bool Sucesso { get; }
        public string Dados { get; }
        public List<Mensagem> Mensagens { get; }
    }
}