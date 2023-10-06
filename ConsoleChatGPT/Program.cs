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

        try
        {
            var httpResponse = await client.PostAsync("https://api.openai.com/v1/completions",
                new StringContent(body, Encoding.UTF8, "application/json"));

            var data = await httpResponse.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<dynamic>(data);
            Console.WriteLine(response?.choices[0].text);
            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            break;
        }
    }
} while (true);