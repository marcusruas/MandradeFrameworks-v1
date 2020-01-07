using MandradePkgs.Retornos.Estrutura.Filtros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MandradePkgs.Retornos.Configuracao
{
    public static class RetornosConfiguracao
    {
        public static void ImplementarFiltrosRetorno(this MvcOptions configuracoes) {
            configuracoes.Filters.Add<ExceptionFiltro>();
            configuracoes.Filters.Add<RetornoFiltro>();
        }
    }
}
