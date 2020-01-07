using Microsoft.Extensions.DependencyInjection;

namespace MandradePkgs.Mensagens.Configuracao
{
    public static class MensagensConfiguracao
    {
        public static void ImplementarMensagensRetorno(this IServiceCollection servicos) =>
            servicos.AddSingleton<MensagensApi>();
    }
}
