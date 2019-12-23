using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Exceptions
{
    public class GenericaException : ApiException
    {
        public GenericaException(string mensagem) : base(mensagem) {
            MensagemPadrao = "Ocorreu uma falha ao realizar a ação solicitada. Reinicie o navegador ou tente novamente mais tarde";
            DescricaoErro = mensagem;
        }

        public GenericaException(string mensagem, string mensagemPadrao) : base(mensagem) {
            MensagemPadrao = mensagemPadrao;
            DescricaoErro = mensagem;
        }

        public override int CodigoRetorno => 7050;

        public override string MensagemPadrao { get; }

        public override string DescricaoErro { get; }
    }
}
