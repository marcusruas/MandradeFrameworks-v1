using System;

namespace MandradePkgs.Retornos.Erros.Exceptions
{
    public abstract class ApiException : Exception
    {
        public ApiException() {
        }

        public abstract int CodigoRetorno { get; }
        public abstract string MensagemPadrao { get; }
        public abstract string DescricaoErro { get; }
    }
}
