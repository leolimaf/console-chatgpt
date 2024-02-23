using ConsoleChatGPT.Domain.Models;

namespace ConsoleChatGPT.Application.Interfaces;

public interface IAplicacaoService
{
    Task<Response> GerarConteudo(Request request);
}