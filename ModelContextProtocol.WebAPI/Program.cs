using ModelContextProtocol.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<WeatherServices>();


builder.Services.AddMcpServer().WithHttpTransport().WithToolsFromAssembly();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapMcp("/mcp");

app.Run();
