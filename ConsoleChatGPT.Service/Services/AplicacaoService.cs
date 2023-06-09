using ConsoleChatGPT.Service.Interfaces;
using ConsoleChatGPT.Service.Models;

namespace ConsoleChatGPT.Service.Services;

public class AplicacaoService : IAplicacaoService
{
    private readonly IBotAPIService _botAPIService;

    public AplicacaoService(IBotAPIService botAPIService)
    {
        _botAPIService = botAPIService;
    }
    
    public async Task<Response> GerarConteudo(Request request)
    {
        if(string.IsNullOrWhiteSpace(request.Mensagem))
            return new Response();
        
        var conteudoGerado = await _botAPIService.GerarConteudo(request);

        if (conteudoGerado.Count == 0)
            return new Response();
        
        return new Response
        {
            Sucesso = true,
            Conteudo = conteudoGerado
        };
    }
}