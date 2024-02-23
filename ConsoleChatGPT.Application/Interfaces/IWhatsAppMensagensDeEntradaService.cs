using ConsoleChatGPT.Domain.Models;

namespace ConsoleChatGPT.Application.Interfaces;

public interface IWhatsAppMensagensDeEntradaService
{
    Task<string> GerarConteudoViaWhatsApp(Request request);
}