using ConsoleChatGPT.Domain.Models;

namespace ConsoleChatGPT.Application.Interfaces;

public interface IChatGptAPIService
{
    Task<string> GerarConteudo(Request request);
}