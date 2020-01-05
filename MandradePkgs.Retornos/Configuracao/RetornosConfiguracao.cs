using MandradePkgs.Retornos.Estrutura.Filtros;
using MandradePkgs.Retornos.Mensagens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MandradePkgs.Retornos.Configuracao
{
    public static class RetornosConfiguracao
    {
        public static void ImplementarMensagensRetorno(this IServiceCollection servicos) =>
            servicos.AddTransient<MensagensApi>();

        public static void ImplementarFiltrosRetorno(this MvcOptions configuracoes) {
            configuracoes.Filters.Add<ExceptionFiltro>();
            configuracoes.Filters.Add<RetornoFiltro>();
        }
    }
}
