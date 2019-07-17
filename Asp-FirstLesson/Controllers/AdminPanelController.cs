using Asp_FirstLesson.Interfaces;
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
        private readonly IRepository<Product> ProductRepository;
        private readonly IRepository<Category> CategoryRepository;
        private readonly IRepository<Role> RoleRepository;
        private readonly IRepository<Producer> ProducerRepository;

        public AdminPanelController(IRepository<Product> repository, IRepository<Category> CategoryRepository, IRepository<Role> RoleRepository, IRepository<Producer> ProducerRepository)
        {
            this.ProductRepository = repository;
            this.CategoryRepository = CategoryRepository;
            this.RoleRepository = RoleRepository;
            this.ProducerRepository = ProducerRepository;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "MY-SHOP.ORG";
            return View();
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            ViewBag.Categories = CategoryRepository.GetAll().ToList();
            ViewBag.Producers = ProducerRepository.GetAll().ToList();
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
                Product prod = ProductRepository.GetAll().FirstOrDefault(a => a.Id == id);
                if (prod == null)
                {
                    return new HttpStatusCodeResult(404);
                }
                else
                {
                    ViewBag.Product = ProductRepository.GetAll().FirstOrDefault(p => p.Id == id);
                    ViewBag.Categories = CategoryRepository.GetAll().ToList();
                    ViewBag.Producers = ProducerRepository.GetAll().ToList();
                    return View();
                }
            }
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductRepository.Add(product);
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
                RoleRepository.Add(role);
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
                ProducerRepository.Add(producer);
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
                CategoryRepository.Add(category);
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
            ProductRepository.Edit(product);
            return new RedirectResult("/Product/GetProducts");
        }
    }
}