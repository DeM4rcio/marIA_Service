using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace app.Services;

public class TokenService
{
     public static string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Valores hardcoded
            var key = Encoding.UTF8.GetBytes(Settings.key);
    
            var expirationMinutes = 60;

            // Configuração do descriptor do token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", username) }),
                Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
        
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Geração do token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
}