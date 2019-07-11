using Asp_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp_FirstLesson.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        ShopContext db = new ShopContext();
        public ActionResult Index()
        {
            ViewBag.Title = "MY-SHOP.ORG";
            return View();
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateProducer()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return new RedirectResult("/Product/GetProducts");
            }
            else
            {
                return new HttpStatusCodeResult(404);
            }
        }
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return new RedirectResult("/Product/GetProducts");
        }
        [HttpPost]
        public ActionResult CreateRole(Role role)
        {
            db.Role.Add(role);
            db.SaveChanges();
            return new RedirectResult("/Product/GetProducts");
        }
        [HttpPost]
        public ActionResult CreateProducer(Producer producer)
        {
            if (ModelState.IsValid)
            {
                db.Producer.Add(producer);
                db.SaveChanges();
                return new RedirectResult("/Product/GetProducts");
            }
            else
            {
                return new HttpStatusCodeResult(404);
            }
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Category.Add(category);
                db.SaveChanges();
                return new RedirectResult("/Product/GetProducts");
            }
            else
            {
                return new HttpStatusCodeResult(404);
            }
        }


    }
}