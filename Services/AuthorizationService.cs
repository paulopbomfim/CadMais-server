using System.Security.Claims;

namespace CadMais.Services;

public class AuthorizationService
{
    public static bool VerifyIdentity(string id, ClaimsPrincipal User)
    {      
        var currentUser = User.FindFirst("Id")?.Value;
        if(currentUser != id)
        {
            return false;
        }

        return true;
    }
}