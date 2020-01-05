using MandradePkgs.Retornos.Erros;
using MandradePkgs.Retornos.Mensagens;
using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos
{
    public class RespostaApiErro
    {
        public RespostaApiErro(ApiExceptionModel erro, MensagensApi mensagens) {
            Sucesso = false;
            Erro = erro;
            Mensagens = mensagens.ObterMensagens();
        }

        public bool Sucesso { get; }
        public ApiExceptionModel Erro { get; }
        public List<Mensagem> Mensagens { get; }
    }
}
