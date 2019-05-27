using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using NTTDataWebFhone.Auth;
using Owin;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


[assembly: OwinStartup(typeof(NTTDataWebFhone.Startup))]
namespace NTTDataWebFhone
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}