using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Exceptions.Implementacao
{
    public class FalhaConexaoException : ApiException
    {
        public FalhaConexaoException(string mensagem) : base(mensagem) {
            MensagemPadrao = "Ocorreu uma falha ao enviar as informações. Reinicie o navegador ou tente novamente mais tarde";
            DescricaoErro = mensagem;
        }

        public FalhaConexaoException(string mensagem, string mensagemPadrao) : base(mensagem) {
            MensagemPadrao = mensagemPadrao;
            DescricaoErro = mensagem;
        }

        public override int CodigoRetorno => 7030;

        public override string MensagemPadrao { get; }

        public override string DescricaoErro { get; }
    }
}
