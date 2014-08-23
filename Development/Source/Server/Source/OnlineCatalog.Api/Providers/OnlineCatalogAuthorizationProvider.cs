using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.ServiceLocation;
using OnlineCatalog.Service.Contracts;

namespace OnlineCatalog.Api.Providers
{
    /// <summary>
    /// bearer Token authorization provider for the application using
    /// OAuth authorization from OWIN
    /// </summary>
    public class OnlineCatalogAuthorizationProvider: OAuthAuthorizationServerProvider
    {
        #region Overrides of OAuthAuthorizationServerProvider

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var userService = ServiceLocator.Current.GetInstance<IUserService>();

            var user = await userService.FindUser(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid-grant", "Invalid username or password");
                return;
            }

            var role = await userService.GetUserRole(user.Id);
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("username", context.UserName));
            identity.AddClaim(new Claim("role", role));

            context.Validated(identity);
        }

        #endregion
    }
}