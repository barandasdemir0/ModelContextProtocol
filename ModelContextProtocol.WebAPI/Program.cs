using ModelContextProtocol.WebAPI.Endpoints;
using ModelContextProtocol.WebAPI.Jwt;
using ModelContextProtocol.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);





#region çağırmalar ve kaydetme
builder.Services.AddTransient<WeatherServices>();
builder.Services.AddTransient<PaymentServices>();
builder.Services.AddTransient<SaleServices>();
builder.Services.AddJwtServices();
builder.Services.AddTransient<TokenService>();
builder.Services.AddMcpServer().WithHttpTransport().WithToolsFromAssembly();
#endregion,

var app = builder.Build();



#region endpointlerim
app.MapGet("/", () => "Hello World!");
app.MapMcp("/mcp").RequireAuthorization();

#region oauth endpointler
app.UseAuthorizationEndpoints();
#endregion
#endregion

app.Run();
