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
        List<Product> products = new List<Product>();
        public ProductController()
        {
            Product product = new Product();
            product.Price = 500;
            product.Id = 1;
            product.Name = "Шоколадка";
            Producer producer = new Producer();
            producer.Name = "Чарли Шоколадная фабрика";
            product.Producer = producer;

            Product product2 = new Product();
            product2.Id = 2;
            product2.Price = 100;
            product2.Name = "Леденец";
            producer.Name = "Чарли Шоколадная фабрика";
            product2.Producer = producer;
            products.Add(product);
            products.Add(product2);
        }
        public ViewResult Index()
        {
            ViewBag.Title = "MY-SHOP.ORG";
            return View();
        }

        public ViewResult GetProducts()
        {

            
            
            StringBuilder builder = new StringBuilder();

            ViewBag.Products = products;
            return View();
            //foreach (var p in products){
            //    builder.Append("Продукт - " + p.Name + " " + "Цена - " + p.Price + " " + "Производитель - " + p.Producer.Name + "<br>");
            //}
            //return builder.ToString();
           
        }
        public ViewResult GetProduct(int id)
        {
            ViewBag.Product = products.SingleOrDefault(p=>p.Id==id);
            return View();
        }
    }
}