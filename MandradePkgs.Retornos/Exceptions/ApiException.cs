using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Exceptions
{
    public abstract class ApiException : Exception
    {
        public ApiException(string mensagem) : base(mensagem) {
        }

        public abstract int CodigoRetorno { get; }
        public abstract string MensagemPadrao { get; }
        public abstract string DescricaoErro { get; }
    }
}
