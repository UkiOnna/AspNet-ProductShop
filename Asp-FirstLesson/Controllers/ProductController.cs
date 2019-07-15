using Asp_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Asp_FirstLesson.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ShopContext db = new ShopContext();
        public ProductController()
        {
            
            db.Role.ToList();
        }
        public ViewResult Index()
        {
            ViewBag.Title = "MY-SHOP.ORG";
            return View();
        }

        public ViewResult GetProducts(int? id)
        {
            ViewBag.Categories = db.Category.ToList();
            ViewBag.Products = db.Product.Where(c => c.CategoryId == id);
            if (id == null)
            {
                ViewBag.Products = db.Product.ToList();
            }
            return View();

        }
        public ActionResult GetProduct(int? id)
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
        public string FillBd()
        {
            db.FillBd(db);
            return "БД успешно заполнена";
        }
    }
}