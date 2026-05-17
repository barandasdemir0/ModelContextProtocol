namespace ModelContextProtocol.WebAPI.Models;

public record AuthCodeData(string Username, string CodeChallenge, DateTime ExpiresAt);
