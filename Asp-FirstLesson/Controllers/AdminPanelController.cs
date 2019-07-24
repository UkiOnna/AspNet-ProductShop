using Asp_FirstLesson.Interfaces;
using Asp_FirstLesson.Models;
using Asp_FirstLesson.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        private readonly IRepository<Producer> ProducerRepository;
        private AppUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        private AppRoleManager RolesManager => HttpContext.GetOwinContext().GetUserManager<AppRoleManager>();

        public AdminPanelController(IRepository<Product> repository, IRepository<Category> CategoryRepository, IRepository<Producer> ProducerRepository)
        {
            this.ProductRepository = repository;
            this.CategoryRepository = CategoryRepository;
            this.ProducerRepository = ProducerRepository;

        }
        public ActionResult Index()
        {
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

        [HttpGet]
        public ActionResult EditCategories()
        {
            ViewBag.Categories = CategoryRepository.GetAll().ToList();
            return View();
        }

        [HttpGet]
        public ActionResult EditProducers()
        {
            ViewBag.Producers = ProducerRepository.GetAll().ToList();
            return View();
        }

        [HttpGet]
        public ActionResult EditUsers()
        {
            ViewBag.Users = UserManager.Users.ToList();
            ViewBag.Roles = RolesManager.Roles.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }
            else
            {
                Category prod = CategoryRepository.GetAll().FirstOrDefault(a => a.Id == id);
                if (prod == null)
                {
                    return new HttpStatusCodeResult(404);
                }
                else
                {
                    ViewBag.Category = prod;
                    return View();
                }
            }
        }

        [HttpGet]
        public ActionResult EditProducer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }
            else
            {
                Producer prod = ProducerRepository.GetAll().FirstOrDefault(a => a.Id == id);
                if (prod == null)
                {
                    return new HttpStatusCodeResult(404);
                }
                else
                {
                    ViewBag.Producer = prod;
                    return View();
                }
            }
        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ViewBag.Roles = RolesManager.Roles.ToList();
                var user = new EditUserViewModel(UserManager.Users.FirstOrDefault(u => u.Id == id));
                return View(user);
            }
            return new HttpStatusCodeResult(404);
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
        public ActionResult CreateProducer(Producer producer)
        {
            if (ModelState.IsValid)
            {
                ProducerRepository.Add(producer);
                return new RedirectResult("/AdminPanel/EditProducers");
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
                return new RedirectResult("/AdminPanel/EditCategories");
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

        [HttpPost]
        public ActionResult EditCategory(Category product)
        {
            CategoryRepository.Edit(product);
            return new RedirectResult("/AdminPanel/EditCategories");
        }

        [HttpPost]
        public ActionResult EditProducer(Producer product)
        {
            ProducerRepository.Edit(product);
            return new RedirectResult("/AdminPanel/EditProducers");
        }

        [HttpPost]
        public ActionResult EditUser(EditUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var updateUser = UserManager.Users.FirstOrDefault(p => p.Id == user.Id);
                updateUser.UserName = user.UserName;
                updateUser.Email = user.Email;
                var roles = UserManager.GetRoles(updateUser.Id);
                UserManager.RemoveFromRole(updateUser.Id, roles.First());
                UserManager.AddToRole(updateUser.Id, RolesManager.FindById(user.RoleId.ToString()).Name);
                UserManager.Update(updateUser);
                return new RedirectResult("~/AdminPanel/EditUsers");
            }
            else
            {
                return new HttpStatusCodeResult(404);
            }

        }
    }
}