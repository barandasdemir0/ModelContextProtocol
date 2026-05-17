using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ModelContextProtocol.WebAPI.Services;

public class TokenService
{

    private readonly string serverUrl = "http://localhost:5000";
    private readonly string jwtSecret = "My secret key My secret key My secret key My secret key My secret key My secret key My secret key My secret key My secret key My secret key My secret key My secret key My secret key My secret key";
    public (string accessToken, string refreshToken) GenerateToken(string username)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        var token = new JwtSecurityToken(
            issuer: serverUrl,
            audience: serverUrl,
            claims: [new Claim(ClaimTypes.Name, username)],
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
        var refreshToken = Guid.NewGuid().ToString("N");

        return (accessToken, refreshToken);
    }

    public string Base64UrlEncode(byte[] bytes) =>
        Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
}
