using System.Security.Authentication;
using ConsoleChatGPT.Service.Interfaces;
using ConsoleChatGPT.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleChatGPT.API.Controllers;

[ApiController]
[Route("api")]
[Produces("application/json")]
public class GeradorController : ControllerBase
{
    private readonly IAplicacaoService _aplicacao;
    
    public GeradorController(IAplicacaoService aplicacao)
    {
        _aplicacao = aplicacao;
    }
    
    [HttpPost, Route("enviar-mensagem")]
    public async Task<ActionResult<Response>> EnviarMensagem(Request request)
    {
        try
        {
            return Ok(await _aplicacao.GerarConteudo(request));
        }
        catch (AuthenticationException)
        {
            return Unauthorized();
        }
    }
}