using MandradePkgs.Retornos.Erros.Exceptions;
using System;

namespace MandradePkgs.Retornos.Erros
{
    public class ApiExceptionModel
    {
        public ApiExceptionModel(int codigoRetorno, string mensagemPadrao, string descricaoErro) {
            CodigoRetorno = codigoRetorno;
            MensagemPadrao = mensagemPadrao;
            DescricaoErro = descricaoErro;
        }

        public ApiExceptionModel(ApiException exception) {
            CodigoRetorno = exception.CodigoRetorno;
            MensagemPadrao = exception.MensagemPadrao;
            DescricaoErro = exception.DescricaoErro;
        }

        public int CodigoRetorno { get; }
        public string MensagemPadrao { get; }
        public string DescricaoErro { get; }
    }
}
