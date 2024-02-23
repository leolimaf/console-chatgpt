using System.ComponentModel.DataAnnotations;

namespace ConsoleChatGPT.Domain.Models;

public class Request
{
    [Required]
    public string Mensagem { get; set; }
}