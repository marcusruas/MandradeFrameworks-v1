using MandradePkgs.Mensagens.Estrutura.Implementacao;
using Microsoft.Extensions.DependencyInjection;

namespace MandradePkgs.Mensagens.Configuracao
{
    public static class MensagensConfiguracao
    {
        public static void ImplementarMensagensServico(this IServiceCollection servicos) =>
            servicos.AddScoped<IMensagensApi, MensagensApi>();
    }
}
