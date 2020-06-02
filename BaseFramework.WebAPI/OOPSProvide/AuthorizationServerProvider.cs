using BaseFramework.Busines.ProjectBaseBusinesInterface;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace BaseFramework.WebAPI.OOPSProvide
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        //private IUserService service;

        //public AuthorizationServerProvider(IUserService _service)
        //{
        //    service = _service;
        //}
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {


            //var User = service.FindwithUsernameandMail(context.UserName, context.Password);
            //if (User != null)
            if (context.UserName.Equals("koray", StringComparison.OrdinalIgnoreCase) && context.Password == "123")
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("UserName", "asd"));
                identity.AddClaim(new Claim("Role", "User"));

                context.Validated(identity);
            }
            else
            {
                context.SetError("Oturum Hatası", "Kullanıcı adı ve şifre hatalıdır");
            }
        }
    }

}