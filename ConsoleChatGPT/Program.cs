using System.Text;
using Newtonsoft.Json;

// CONSOLE UTILIZADO PARA TESTAR A API DO CHATGPT
do
{
    var input = Console.ReadLine();

    if (input?.Length <= 0)
        Console.WriteLine("Entrada inválida!\n");
    else
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("authorization",
            "Bearer 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");

        var body = JsonConvert.SerializeObject(new
        {
            model = "text-davinci-003",
            prompt = input,
            max_tokens = 500,
            temperature = 0
        });

        var httpResponse = await client.PostAsync("https://api.openai.com/v1/completions",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var data = await httpResponse.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<dynamic>(data);
        Console.WriteLine(response?.choices[0].text);
        Console.WriteLine();
    }
} while (true);