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
    
    /// <summary>
    /// Envia uma mensagem para a API do ChatGPT
    /// </summary>
    /// <returns>Coleção de respostas e atributo booleano incicando se a requisição foi bem-sucedida</returns>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     {
    ///        "mensagem": "Um avião contém 4 passageiros romanos e uma aeromoça inglesa. Qual é o nome da aeromoça?"
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