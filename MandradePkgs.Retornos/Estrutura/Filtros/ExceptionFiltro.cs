using MandradePkgs.Mensagens;
using MandradePkgs.Retornos.Erros;
using MandradePkgs.Retornos.Erros.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MandradePkgs.Retornos.Estrutura.Filtros
{
    internal class ExceptionFiltro : IExceptionFilter
    {
        public void OnException(ExceptionContext context) {
            int codigoResultado;
            ApiException exceptionTratada;
            var _mensagens = (MensagensApi)context.HttpContext.RequestServices.GetService(typeof(MensagensApi));

            if (context.Exception is FalhaExecucaoException) {
                exceptionTratada = new FalhaExecucaoException(context.Exception.Message);
                codigoResultado = 500;
            }
            else if (context.Exception is FalhaConexaoExternaException) {
                exceptionTratada = new FalhaConexaoExternaException(context.Exception.Message);
                codigoResultado = 503;
            }
            else if (context.Exception is FalhaConexaoException) {
                exceptionTratada = new FalhaConexaoException(context.Exception.Message);
                codigoResultado = 503;
            }
            else if (context.Exception is RegraNegocioException) {
                exceptionTratada = new RegraNegocioException(context.Exception.Message);
                codigoResultado = 400;
            }
            else {
                exceptionTratada = new GenericaException(context.Exception.Message);
                codigoResultado = 422;
            }

            ApiExceptionModel exceptionModel = new ApiExceptionModel(exceptionTratada);

            context.HttpContext.Response.StatusCode = codigoResultado;
            context.Result = new ObjectResult(new RespostaApiErro(exceptionModel, _mensagens));
        }
    }
}
