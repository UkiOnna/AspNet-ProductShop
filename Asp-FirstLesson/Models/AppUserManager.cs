using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.Models
{
    public class AppUserManager : UserManager<User>
    {
        public AppUserManager(IUserStore<User> store) : base(store)
        {
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,
                                            IOwinContext context)
        {
            var db = context.Get<ShopContext>();
            var manager = new AppUserManager(new UserStore<User>(db));

            return manager;
        }
    }
}