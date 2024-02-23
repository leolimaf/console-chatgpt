using ConsoleChatGPT.Domain.Models;

namespace ConsoleChatGPT.Application.Interfaces;

public interface IBotAPIService
{
    Task<List<string>> GerarConteudo(Request request);
}