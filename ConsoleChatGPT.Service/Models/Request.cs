using System.ComponentModel.DataAnnotations;

namespace ConsoleChatGPT.Service.Models;

public class Request
{
    [Required]
    public string Mensagem { get; set; }
}