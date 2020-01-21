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
            var _mensagens = (IMensagensApi)context.HttpContext.RequestServices.GetService(typeof(IMensagensApi));

            if(context.Exception is ApiException) {
                var msgTratada = ((ApiException)context.Exception).DescricaoErro;
                if (context.Exception is FalhaExecucaoException) {
                    exceptionTratada = new FalhaExecucaoException(msgTratada);
                    codigoResultado = 500;
                }
                else if (context.Exception is FalhaConexaoExternaException) {
                    exceptionTratada = new FalhaConexaoExternaException(msgTratada);
                    codigoResultado = 503;
                }
                else if (context.Exception is FalhaConexaoException) {
                    exceptionTratada = new FalhaConexaoException(msgTratada);
                    codigoResultado = 503;
                }
                else if (context.Exception is RegraNegocioException) {
                    exceptionTratada = new RegraNegocioException(msgTratada);
                    codigoResultado = 400;
                }
                else {
                    exceptionTratada = new GenericaException(msgTratada);
                    codigoResultado = 422;
                }
            }else {
                exceptionTratada = new GenericaException(context.Exception.Message);
                codigoResultado = 500;
            }

            ApiExceptionModel exceptionModel = new ApiExceptionModel(exceptionTratada);

            context.HttpContext.Response.StatusCode = codigoResultado;
            context.Result = new ObjectResult(new RespostaApiErro(exceptionModel, _mensagens.Mensagens));
        }
    }
}
