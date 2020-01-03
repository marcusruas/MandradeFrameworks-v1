using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Estrutura.Filtros
{
    public class RetornoFiltro : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) {
            
        }

        public void OnActionExecuting(ActionExecutingContext context) {
        }
    }
}
