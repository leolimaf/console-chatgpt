using ConsoleChatGPT.Service.Models;

namespace ConsoleChatGPT.Service.Interfaces;

public interface IBotAPIService
{
    Task<List<string>> GerarConteudo(Request request);
}