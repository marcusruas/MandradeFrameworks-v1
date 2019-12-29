using MandradePkgs.Retornos.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MandradePkgs.Retornos.Estrutura.Filtros
{
    public class ExceptionFiltro : IExceptionFilter
    {
        public void OnException(ExceptionContext context) {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = 400;

            using (StreamWriter sr = new StreamWriter(context.HttpContext.Response.Body)) {
                var retorno = new RespostaApi(context.Exception);
                sr.Write(JsonConvert.SerializeObject(retorno));
                sr.Flush();
            }
        }
    }
}
