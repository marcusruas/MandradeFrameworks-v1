using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Exceptions
{
    public class DominioException : ApiException
    {
        public DominioException(string mensagem) : base(mensagem) {
            Mensagem = mensagem;
        }

        public override int CodigoRetorno => 7010;

        public override string Mensagem { get; }
    }
}
