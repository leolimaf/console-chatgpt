using ConsoleChatGPT.Service.Interfaces;
using ConsoleChatGPT.Service.Models;
using Microsoft.Extensions.Configuration;
using OpenAI_API;

namespace ConsoleChatGPT.Infrastructure.Network;

public class BotAPIService : IBotAPIService
{
    private readonly IConfiguration _configuration;

    public BotAPIService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<string>> GerarConteudo(Request request)
    {
        var apiKey = _configuration.GetSection("Appsettings:ChatGPTAPIKEY").Value;
        var apiModel = _configuration.GetSection("Appsettings:Model").Value;
        
        OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));
        
        var completionRequest = new OpenAI_API.Completions.CompletionRequest
        {
            Prompt = request.Mensagem,
            Model = apiModel,
            Temperature = 0.5,
            MaxTokens = 100,
            TopP = 1.0,
            FrequencyPenalty = 0.0,
            PresencePenalty = 0.0,

        };
        var result = await api.Completions.CreateCompletionsAsync(completionRequest);
        return result.Completions.Select(choice => choice.Text).ToList();
    }
}