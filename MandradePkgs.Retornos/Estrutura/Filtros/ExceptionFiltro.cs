using MandradePkgs.Retornos.Exceptions;
using MandradePkgs.Retornos.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MandradePkgs.Retornos.Estrutura.Filtros
{
    internal class ExceptionFiltro : IExceptionFilter
    {
        public void OnException(ExceptionContext context) {
            var body = context.HttpContext.Response.Body;
            context.HttpContext.Response.StatusCode = 400;
            using (StreamWriter sr = new StreamWriter(body)) {
                var retorno = new RespostaApi(context.Exception);
                sr.Write(retorno);
                sr.Flush();
            }
        }
    }
}
