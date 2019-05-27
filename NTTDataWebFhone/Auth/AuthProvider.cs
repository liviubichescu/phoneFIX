using Microsoft.Owin.Security.OAuth;
using PhoneFix.BLL.Services.AuthService;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NTTDataWebFhone.Auth
{
    public class AuthProvider: OAuthAuthorizationServerProvider
    {
        AuthService authService = new AuthService();

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var userID = authService.Login(context.UserName, context.Password);

            if (userID == 0)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);


            identity.AddClaim(new Claim("sub", userID.ToString()));
            //identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);

        }
    }
}