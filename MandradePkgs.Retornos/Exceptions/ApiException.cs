using MandradePkgs.Retornos.Estrutura.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Exceptions
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
