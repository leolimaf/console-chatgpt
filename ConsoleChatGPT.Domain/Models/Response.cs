namespace ConsoleChatGPT.Domain.Models;

public class Response
{
    public List<string> Conteudo { get; set; } = new();
    public bool Sucesso { get; set; }
}