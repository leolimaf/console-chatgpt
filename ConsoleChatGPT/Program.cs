using System.Text;
using Newtonsoft.Json;

// CONSOLE UTILIZADO PARA TESTAR A API DO CHATGPT
do
{
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        break;
    
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("authorization",
        "Bearer sk-fgsgsgssrgvrsgsg");

    var body = JsonConvert.SerializeObject(new
    {
        model = "gpt-3.5-turbo",
        messages =  new []
        {
            new {
                role = "system",
                content = "You are an expert in software development, skilled at explaining technology concepts used by Microsoft."
            },
            new {
                role = "user",
                content = input
            }
        }
    });

    try
    {
        var httpResponse = await client.PostAsync("https://api.openai.com/v1/chat/completions",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var data = await httpResponse.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<dynamic>(data);
        Console.WriteLine(response?.choices[0].message.content);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        break;
    }
} while (true);