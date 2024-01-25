using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace NoteApp.Core;

public class SecurityKeyHelper
{
    public static SecurityKey CreateSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}
