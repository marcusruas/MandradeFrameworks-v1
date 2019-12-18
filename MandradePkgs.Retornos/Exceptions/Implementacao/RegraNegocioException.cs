using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Exceptions.Implementacao
{
    public class RegraNegocioException : ApiException
    {
        public RegraNegocioException(string mensagem) : base(mensagem) {
            MensagemPadrao = "Informações digitadas erradas. Verifique as informações e tente novamente.";
            DescricaoErro = mensagem;
        }

        public RegraNegocioException(string mensagem, string mensagemPadrao) : base(mensagem) {
            MensagemPadrao = mensagemPadrao;
            DescricaoErro = mensagem;
        }

        public override int CodigoRetorno => 7010;

        public override string MensagemPadrao { get; }

        public override string DescricaoErro { get; }
    }
}
