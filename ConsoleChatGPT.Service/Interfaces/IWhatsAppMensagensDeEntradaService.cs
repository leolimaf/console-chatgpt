using ConsoleChatGPT.Service.Models;

namespace ConsoleChatGPT.Service.Interfaces;

public interface IWhatsAppMensagensDeEntradaService
{
    Task<string> GerarConteudoViaWhatsApp(Request request);
}