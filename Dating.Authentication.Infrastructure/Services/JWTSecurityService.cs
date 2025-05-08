namespace Dating.Authentication.Infrastructure.Services;

public class JWTSecurityService(IConfiguration configuration)
    : IJWTSecurityService
{
    public string CreateToken(User user)
    {
        string secretKey = configuration["AuthSettings:SecretKey"]!;

        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
        };

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(secretKey));

        SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenHandler = new JsonWebTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = creds,
            Subject = new ClaimsIdentity(claims),
            IssuedAt = DateTime.UtcNow,
            NotBefore = DateTime.UtcNow.AddMinutes(0),
            Expires = DateTime.UtcNow.AddDays(30),
        };

        string token = tokenHandler.CreateToken(tokenDescriptor);

        return token;
    }
}