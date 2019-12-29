using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Exceptions
{
    public class FalhaExecucaoException : ApiException
    {
        public FalhaExecucaoException(string mensagem) {
            MensagemPadrao = "Ocorreu uma falha ao executar a ação. Contate o Suporte para mais informações.";
            DescricaoErro = mensagem;
        }

        public FalhaExecucaoException(string mensagem, string mensagemPadrao) {
            MensagemPadrao = mensagemPadrao;
            DescricaoErro = mensagem;
        }

        public override int CodigoRetorno => 7020;

        public override string MensagemPadrao { get; }

        public override string DescricaoErro { get; }
    }
}
