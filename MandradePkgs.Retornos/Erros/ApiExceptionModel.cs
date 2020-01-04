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
            DescricaoErro = exception.Message;
        }

        public ApiExceptionModel(Exception exception) {
            var erro = new FalhaExecucaoException(exception.Message);
            CodigoRetorno = erro.CodigoRetorno;
            MensagemPadrao = erro.MensagemPadrao;
            DescricaoErro = erro.Message;
        }

        public int CodigoRetorno { get; }
        public string MensagemPadrao { get; }
        public string DescricaoErro { get; }
    }
}
