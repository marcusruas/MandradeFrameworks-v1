using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Exceptions
{
    public class FalhaExecucaoException : ApiException
    {
        public FalhaExecucaoException(string mensagem) : base(mensagem) {
            Mensagem = mensagem;
        }

        public override int CodigoRetorno => 7020;

        public override string Mensagem { get; }
    }
}
