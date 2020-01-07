using MandradePkgs.Mensagens;
using MandradePkgs.Retornos.Erros;
using System.Collections.Generic;

namespace MandradePkgs.Retornos
{
    public class RespostaApiErro
    {
        public RespostaApiErro(ApiExceptionModel erro, MensagensApi mensagens) {
            Sucesso = false;
            Dados = erro;
            Mensagens = mensagens.ObterMensagens();
        }

        public bool Sucesso { get; }
        public ApiExceptionModel Dados { get; }
        public List<Mensagem> Mensagens { get; }
    }
}
