using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos
{
    public abstract class ApiException
    {
        public ApiException() {
        }

        public abstract int CodigoRetorno { get; }
        public abstract string MensagemPadrao { get; }
        public abstract string DescricaoErro { get; }
    }
}
