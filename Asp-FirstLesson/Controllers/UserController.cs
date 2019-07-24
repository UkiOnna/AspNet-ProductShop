using Asp_FirstLesson.Attributes;
using Asp_FirstLesson.Interfaces;
using Asp_FirstLesson.Models;
using Asp_FirstLesson.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Asp_FirstLesson.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private AppUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
        private AppRoleManager RolesManager => HttpContext.GetOwinContext().GetUserManager<AppRoleManager>();

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Users.FirstOrDefault(u => u.UserName == loginModel.Username);
                if (user == null)
                {
                    return new RedirectResult("/User/Registration");
                }

                ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignOut();
                AuthenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = true,
                }, claim);

                return new RedirectResult("/Home/Index");
            }
            else
            {
                return View(loginModel);
            }
        }


        [HttpGet]
        [NotAuthorize]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            if (User.Identity != null)
            {
                AuthenticationManager.SignOut();
            }
            return new RedirectResult("/Home/Index");
        }


        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registration(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Login, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "user");
                    return new RedirectResult("/Home/Index");
                }
                else
                {
                    return View(model);
                }

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult GetInformation()
        {
            ViewBag.User = UserManager.Users.FirstOrDefault(user => user.UserName == User.Identity.Name);
            var roles = UserManager.GetRoles(User.Identity.GetUserId());
            ViewBag.Role = roles.First();
            return View();
        }
    }
}