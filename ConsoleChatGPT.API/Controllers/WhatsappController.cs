using System.Security.Authentication;
using ConsoleChatGPT.Application.Interfaces;
using ConsoleChatGPT.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace ConsoleChatGPT.API.Controllers;

[ApiController]
[Route("api")]
[Produces("application/xml")]
public class WhatsappController : TwilioController
{
    private readonly IWhatsAppMensagensDeEntradaService _whatsAppMensagensDeEntradaService;

    public WhatsappController(IWhatsAppMensagensDeEntradaService whatsAppMensagensDeEntradaService)
    {
        _whatsAppMensagensDeEntradaService = whatsAppMensagensDeEntradaService;
    }
    
    /// <summary> Envia uma mensagem para a API do ChatGPT - Endpoint para utilização do WhatsApp integrado a Twillio </summary>
    /// <returns>Resposta do ChatGPT</returns>
    [HttpPost, Route("enviar-mensagem-via-whatsapp")]
    public async Task<IActionResult> EnviarMensagemViaWhatsApp()
    {
        try
        {
            var msg = new MessagingResponse();
            string msgs = Request.Form["Body"];
            var request = new Request
            {
                Mensagem = msgs
            };
            var response = await _whatsAppMensagensDeEntradaService.GerarConteudoViaWhatsApp(request);
            return new MessagingResponse().Message($"{response}").ToTwiMLResult();
        }
        catch (AuthenticationException)
        {
            return Unauthorized();
        }

    }
}