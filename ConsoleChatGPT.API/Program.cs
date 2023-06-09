using System.Reflection;
using ConsoleChatGPT.Infrastructure.Network;
using ConsoleChatGPT.Service.Interfaces;
using ConsoleChatGPT.Service.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IAplicacaoService, AplicacaoService>();
builder.Services.AddScoped<IBotAPIService, BotAPIService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options .SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Console ChatGPT - API",
        Version = "v1",
        Description = "Aplicação Web API feita em ASP.NET Core integrada ao ChatGPT",
        Contact = new OpenApiContact
        {
            Name = "Leonardo Lima",
            Url = new Uri("https://leolimaf.github.io")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts => opts.DocumentTitle = "Console ChatGPT - API");
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI(opts =>
{
    opts.SwaggerEndpoint("/swagger/v1/swagger.json", "Console ChatGPT - API");
    opts.RoutePrefix = string.Empty;
    opts.InjectStylesheet("/assets/css/custom.css");
});
app.MapControllers();

app.Run();