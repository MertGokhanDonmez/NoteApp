using Microsoft.IdentityModel.Tokens;

namespace NoteApp.Core;

public class SigningCredentialsHelper
{
    public static SigningCredentials CreateSigningCredentials(SecurityKey security)
    {
        return new SigningCredentials(security, SecurityAlgorithms.HmacSha512Signature);
    }
}
