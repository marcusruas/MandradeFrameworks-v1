using MandradePkgs.Retornos.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Estrutura.Models
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

        public ApiExceptionModel(Exception exception) {
            var erro = new FalhaExecucaoException(exception.Message);
            CodigoRetorno = erro.CodigoRetorno;
            MensagemPadrao = erro.MensagemPadrao;
            DescricaoErro = erro.DescricaoErro;
        }

        public int CodigoRetorno { get; }
        public string MensagemPadrao { get; }
        public string DescricaoErro { get; }
    }
}
