using Asp_FirstLesson.App_Start;
using Asp_FirstLesson.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
[assembly: OwinStartup(typeof(Startup))]
namespace Asp_FirstLesson.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            builder.CreatePerOwinContext(()=>new ShopContext());
            builder.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            builder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}