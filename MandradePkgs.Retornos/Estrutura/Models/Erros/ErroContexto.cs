using MandradePkgs.Retornos.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Estrutura.Models.Erros
{
    public class ErroContexto
    {
        public ErroContexto(ApiException exception) {
            CodigoRetorno = exception.CodigoRetorno;
            MensagemPadrao = exception.MensagemPadrao;
            DescricaoErro = exception.DescricaoErro;
        }

        public ErroContexto(int codigoRetorno, string mensagemPadrao, string descricaoErro) {
            CodigoRetorno = codigoRetorno;
            MensagemPadrao = mensagemPadrao;
            DescricaoErro = descricaoErro;
        }

        public int CodigoRetorno { get; }

        public string MensagemPadrao { get; }

        public string DescricaoErro { get; }
    }
}
