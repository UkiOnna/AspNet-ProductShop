using Asp_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp_FirstLesson.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        ShopContext db = new ShopContext();
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(User user)
        {
            
            if (ModelState.IsValid)
            {
                User user1 = db.User.SingleOrDefault(p => p.Login == user.Login);
                if (user1 == null)
                {
                    user.RoleId = 1;
                    db.User.Add(user);
                    db.SaveChanges();
                    return new RedirectResult("/Home/Index");
                }
                else
                {
                    return new HttpStatusCodeResult(404);
                }
            }
            return View("Registration");
        }
    }
}