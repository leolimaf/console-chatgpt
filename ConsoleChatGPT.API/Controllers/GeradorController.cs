using System.Security.Authentication;
using ConsoleChatGPT.Application.Interfaces;
using ConsoleChatGPT.Domain.Models;
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
    
    /// <summary> Envia uma mensagem para a API do ChatGPT </summary>
    /// <returns>Coleção de respostas e atributo booleano indicando se a requisição foi bem-sucedida</returns>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     {
    ///        "mensagem": "Quem foi Alan Turing?"
    ///     }
    ///
    /// </remarks>
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