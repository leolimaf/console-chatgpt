using ConsoleChatGPT.Application.Interfaces;
using ConsoleChatGPT.Domain.Models;

namespace ConsoleChatGPT.Application.Services;

public class AplicacaoService : IAplicacaoService, IWhatsAppMensagensDeEntradaService
{
    private readonly IChatGptAPIService _chatGptApiService;

    public AplicacaoService(IChatGptAPIService chatGptApiService)
    {
        _chatGptApiService = chatGptApiService;
    }
    
    public async Task<Response> GerarConteudo(Request request)
    {
        if(string.IsNullOrWhiteSpace(request.Mensagem))
            return new Response();
        
        var conteudoGerado = await _chatGptApiService.GerarConteudo(request);

        if (string.IsNullOrWhiteSpace(conteudoGerado))
            return new Response();
        
        return new Response
        {
            Sucesso = true,
            Conteudo = conteudoGerado
        };
    }

    public async Task<string> GerarConteudoViaWhatsApp(Request request)
    {
        return (await GerarConteudo(request)).Conteudo;
    }
}