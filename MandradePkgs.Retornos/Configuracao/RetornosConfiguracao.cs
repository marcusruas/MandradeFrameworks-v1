using MandradePkgs.Retornos.Estrutura.Filtros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Configuracao
{
    public static class RetornosConfiguracao
    {
        public static void ImplementarFiltrosRetorno(this MvcOptions configuracoes) {
            configuracoes.Filters.Add(typeof(ExceptionFiltro));
        }
    }
}
