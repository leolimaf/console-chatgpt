using ConsoleChatGPT.Application.Interfaces;
using ConsoleChatGPT.Domain.Models;
using ConsoleChatGPT.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace ConsoleChatGPT.Infrastructure.Network;

public class ChatGptApiService : IChatGptAPIService
{
    private readonly ChatGptSettings _chatGptSettings;

    public ChatGptApiService(IOptions<ChatGptSettings> chatGptOptions)
    {
        _chatGptSettings = chatGptOptions.Value;
    }

    public async Task<string> GerarConteudo(Request request)
    {
        var apiKey = _chatGptSettings.ChatGptApiKey;
        
        var api = new OpenAIAPI(new APIAuthentication(apiKey));

        var result = await api.Chat.CreateChatCompletionAsync(new ChatRequest
        {
            Model = Model.ChatGPTTurbo,
            Temperature = 0.1,
            MaxTokens = 50,
            Messages = new[]
            {
                new ChatMessage(ChatMessageRole.User, request.Mensagem)
            }
        });
        var reply = result.Choices[0].Message;
        return reply.TextContent;
    }
}