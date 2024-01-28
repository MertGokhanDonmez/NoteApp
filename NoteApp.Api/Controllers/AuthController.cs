using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace NoteApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController
{
    string signingKey = "KsdhasJHadDlDflS7sDJdsla48hdf45DAfjkhdaf6n";
    [HttpGet]
    public string Get(string userName, string password)
    {
        var claims = new[]{
            new Claim(ClaimTypes.Name,userName),
            new Claim(JwtRegisteredClaimNames.Email,userName)

        };
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

        var jwtSecurityToken = new JwtSecurityToken(
            audience: "test@test.com",
            issuer: "test@test.com",
            claims: claims,
            expires: DateTime.Now.AddDays(15),
            notBefore: DateTime.Now,
            signingCredentials: credential
        );
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return token;
    }

    [HttpGet("ValidateToken")]
    public bool ValidateToken(string token)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        try
        {
            JwtSecurityTokenHandler handler = new();
            handler.ValidateToken(token, new TokenValidationParameters(){
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false
            }, out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            var claims = jwtToken.Claims.ToList();
            return true;
        }
        catch (System.Exception)
        {
            return false;            
        }
    }
}
