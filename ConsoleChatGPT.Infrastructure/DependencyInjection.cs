using ConsoleChatGPT.Application.Interfaces;
using ConsoleChatGPT.Infrastructure.Network;
using ConsoleChatGPT.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ConsoleChatGPT.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddChatBotAuth(configuration);
        services.AddScoped<IChatGptAPIService, ChatGptApiService>();
        
        return services;
    }

    private static IServiceCollection AddChatBotAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var chatGptSettings = new ChatGptSettings();
        configuration.Bind(ChatGptSettings.SectionName, chatGptSettings);

        services.AddSingleton(Options.Create(chatGptSettings));
        
        return services;
    }
}