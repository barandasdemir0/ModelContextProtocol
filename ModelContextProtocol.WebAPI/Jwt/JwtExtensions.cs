using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ModelContextProtocol.AspNetCore.Authentication;
using System.Text;

namespace ModelContextProtocol.WebAPI.Jwt;

public static class JwtExtensions
{
    public static void AddJwtServices(this IServiceCollection services)
    {
        var serverUrl = "http://localhost:5000";
        var jwtSecret = "My secret key My secret key My secret key My secret key My secret key My secret key My secret key My secret key My secret key My secret key My secret key My secret key My secret key My secret key";
        var jwtIssuer = serverUrl;   // "Issuer" yerine serverUrl
        var jwtAudience = serverUrl; // "Audience" yerine serverUrl

        services.AddAuthentication(options =>
        {
            options.DefaultChallengeScheme = McpAuthenticationDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters.ValidateIssuer = true;
            opt.TokenValidationParameters.ValidateAudience = true;
            opt.TokenValidationParameters.ValidateIssuerSigningKey = true;
            opt.TokenValidationParameters.ValidateLifetime = true;
            opt.TokenValidationParameters.ValidIssuer = jwtIssuer;
            opt.TokenValidationParameters.ValidAudience = jwtAudience;
            opt.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        })
        .AddMcp(options =>
        {
            options.ResourceMetadata = new()
            {
                Resource = serverUrl,
                // Auth server'ınızın OAuth 2.0 metadata endpoint'i olmalı
                // GET /.well-known/oauth-authorization-server döndürmeli
                AuthorizationServers = { serverUrl },
                ScopesSupported = ["mcp:tools"]
            };
        });
        services.AddAuthorization();

        services.AddHttpContextAccessor();

         
    }
}
