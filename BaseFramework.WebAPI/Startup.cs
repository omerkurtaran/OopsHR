using System;
using System.Threading.Tasks;
using System.Web.Http;
using BaseFramework.MapConfig.Configprofile;
using BaseFramework.WebAPI.OOPSProvide;
using BaseFramework.WebAPI.RegisterCore;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(BaseFramework.WebAPI.Startup))]

namespace BaseFramework.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration configuration = new HttpConfiguration();
            configuration.DependencyResolver = IocContainerConfig.RegisterDependencies();

            SwaggerConfig.Register(configuration);

            Configure(app);

            WebApiConfig.Register(configuration);
            app.UseWebApi(configuration);

        }

        private void Configure(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new Microsoft.Owin.PathString("/getToken"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                AllowInsecureHttp = true,
                Provider = new AuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

    }
}
