using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NoteApp.DataAccess.Abstract;
using NoteApp.Entities.Concrete;

namespace NoteApp.DataAccess;

public class TokenHandler : ITokenHandler
{
    private readonly IConfiguration _configuration;
    public TokenHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Token CreateAccessToken(int minute)
    {
        Token token = new();

        //Security key'in simetrigini aliyoruz.
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenOptions:SecurityKey"]));

        //Sifrelenmis kimligi olusturuyoruz
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);

        //olusturulacak token ayarlarini veriyoruz
        token.Expiration = DateTime.UtcNow.AddMinutes(minute);

        JwtSecurityToken securityToken = new(
            audience : _configuration["Token: Audience"],
            issuer : _configuration["Token : Issuer"],
            expires : token.Expiration,
            notBefore : DateTime.UtcNow,
            signingCredentials : signingCredentials
        );

        //Token olusturucu sinifindan bir ornek alalim
        JwtSecurityTokenHandler tokenHandler = new();
        token.AccessToken = tokenHandler.WriteToken(securityToken);
        return token;
    }
}