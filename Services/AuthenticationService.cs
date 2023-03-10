using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

using CadMais.Models;

namespace CadMais.Services;

public class AuthenticationService
{
  private static ClaimsIdentity AddClaims(User user)
  {
    var claims = new ClaimsIdentity();

    claims.AddClaim(new Claim(ClaimTypes.Name, user.Name));
    claims.AddClaim(new Claim("Id", value: user.Id.ToString()));
    claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));

    return claims;
  }

  public string GenerateToken(User user)
  {
    var tokenHandler = new JwtSecurityTokenHandler();

    var tokenDescriptor = new SecurityTokenDescriptor()
    {
      Subject = AddClaims(user),
      SigningCredentials = new SigningCredentials(
        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.JwtSecret)),
        SecurityAlgorithms.HmacSha256Signature
      ),
      Expires = DateTime.Now.AddDays(1)
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);

    return tokenHandler.WriteToken(token);
  }
}