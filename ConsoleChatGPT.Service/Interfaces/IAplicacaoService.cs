using ConsoleChatGPT.Service.Models;

namespace ConsoleChatGPT.Service.Interfaces;

public interface IAplicacaoService
{
    Task<Response> GerarConteudo(Request request);
}