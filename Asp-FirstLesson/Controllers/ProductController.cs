using Asp_FirstLesson.Data;
using Asp_FirstLesson.Interfaces;
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
        private readonly IRepository<Product> ProductRepository;
        private readonly IRepository<Category> CategoryRepository;

        // GET: Product
        //ShopContext db = new ShopContext();


        public ProductController(IRepository<Product> repository,IRepository<Category> CategoryRepository)
        {
            ProductRepository = repository;
            this.CategoryRepository = CategoryRepository;
        }

        public ViewResult Index()
        {
            ViewBag.Title = "MY-SHOP.ORG";
            return View();
        }

        public ViewResult GetProducts(int? id)
        {

            ViewBag.Categories = CategoryRepository.GetAll().ToList();
            ViewBag.Products = ProductRepository.GetAll().Where(c => c.CategoryId == id);
            if (id == null)
            {
                ViewBag.Products =ProductRepository.GetAll().ToList();
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
                Product prod = ProductRepository.GetAll().FirstOrDefault(a => a.Id == id);
                if (prod == null)
                {
                    return new HttpStatusCodeResult(404);
                }
                else
                {
                    ViewBag.Product = ProductRepository.GetAll().FirstOrDefault(p => p.Id == id);
                    return View();
                }
            }
        }
    }
}