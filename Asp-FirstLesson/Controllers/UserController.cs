using Asp_FirstLesson.Interfaces;
using Asp_FirstLesson.Models;
using Asp_FirstLesson.ViewModels;
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
        private readonly IRepository<User> UserRepository;
        public UserController(IRepository<User> repository)
        {
            UserRepository = repository;
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(UserViewModel user)
        {
            
            if (ModelState.IsValid && user.Password == user.SecondPassword)
            {
                User user1 = UserRepository.GetAll().SingleOrDefault(p => p.Login == user.Login);
                if (user1 == null)
                {
                    User user2 = user.GetUser();
                    UserRepository.Add(user2);
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