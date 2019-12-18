using MandradePkgs.Retornos.Exceptions;
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
            context.HttpContext.Response.StatusCode = 7010;
            using (StreamWriter sr = new StreamWriter(body)) {
                
                sr.Write(retorno);
                sr.Flush();
            }
        }
    }
}
