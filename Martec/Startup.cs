using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Martec.Web;

[assembly: OwinStartup(typeof(Martec.Web.Startup))]

namespace Martec.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = Constants.Authentication.Type,
                LoginPath = new PathString(Constants.Authentication.Path)
            });
        }
    }
}
