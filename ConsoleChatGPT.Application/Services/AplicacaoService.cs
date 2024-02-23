using ConsoleChatGPT.Application.Interfaces;
using ConsoleChatGPT.Domain.Models;

namespace ConsoleChatGPT.Application.Services;

public class AplicacaoService : IAplicacaoService, IWhatsAppMensagensDeEntradaService
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

    public async Task<string> GerarConteudoViaWhatsApp(Request request)
    {
        var response = await GerarConteudo(request);
        return response.Conteudo[2];
    }
}