using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PasswordManagerAPI.Models;

namespace PasswordManagerAPI.Services;

/* classe que gera o token */
public class TokenService
{
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        /* criando variavel com a key em bytes */
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
        /* configurando especificação do token */
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            /* conteúdo do token ( payload: data ) */
            Subject = new ClaimsIdentity(new Claim[]
            {
                new (ClaimTypes.Name, "") // User.Identity.Name
            }),
            
            /* expiração do token */
            Expires = DateTime.UtcNow.AddHours(8),

            /* assinatura do token */
            SigningCredentials = new SigningCredentials(
                /* key e método de encriptação */
                new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}