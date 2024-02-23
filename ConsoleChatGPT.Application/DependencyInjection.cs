using ConsoleChatGPT.Application.Interfaces;
using ConsoleChatGPT.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleChatGPT.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAplicacaoService, AplicacaoService>();
        services.AddScoped<IWhatsAppMensagensDeEntradaService, AplicacaoService>();

        return services;
    }
}