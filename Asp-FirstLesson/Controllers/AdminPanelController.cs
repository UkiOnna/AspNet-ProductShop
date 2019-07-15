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

        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }
            else
            {
                Product prod = db.Product.FirstOrDefault(a => a.Id == id);
                if (prod == null)
                {
                    return new HttpStatusCodeResult(404);
                }
                else
                {
                    ViewBag.Product = db.Product.FirstOrDefault(p => p.Id == id);
                    return View();
                }
            }
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
        public ActionResult CreateRole(Role role)
        {
            if (ModelState.IsValid)
            {
                db.Role.Add(role);
                db.SaveChanges();
                return new RedirectResult("/Product/GetProducts");
            }
            else
            {
                return new HttpStatusCodeResult(404);
            }
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

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            Product product1 = db.Product.SingleOrDefault(s => s.Id == product.Id);
            if (ModelState.IsValid && product1 != null)
            {
                product1.Name = product.Name;
                product1.Price = product.Price;
                product1.ProducerId = product.ProducerId;
                product1.CategoryId = product.CategoryId;
                product1.Category = product.Category;
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