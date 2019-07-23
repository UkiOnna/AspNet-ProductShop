using Asp_FirstLesson.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Asp_FirstLesson.Data
{
    public class ShopContextInitializer:CreateDatabaseIfNotExists<ShopContext>
    {
        protected override void Seed(ShopContext db)
        {
            var store = new RoleStore<IdentityRole>(db);
            var roleManager = new AppRoleManager(store);
            roleManager.Create(new IdentityRole("user"));
            roleManager.Create(new IdentityRole("admin"));
            var userManager = new AppUserManager(new UserStore<User>(db));
            var user = new User { UserName = "UkiOnna", Email = "lol@mail.ru" };
            var result = userManager.Create(user,"qwerty-123");
            userManager.AddToRole(user.Id, "admin");
            var user1 = new User { UserName = "Star", Email = "lox@mail.ru" };
            var result1 = userManager.Create(user1, "qwerty-123");
            userManager.AddToRole(user1.Id, "user");
            Producer producer = new Producer { Name = "Сладкая сказка" };
            Producer producer1 = new Producer { Name = "Яшкино" };
            db.Producer.Add(producer);
            db.Producer.Add(producer1);
            Category category = new Category { Name = "Сладости" };
            Category category1 = new Category { Name = "Выпечка" };
            db.Category.Add(category);
            db.Category.Add(category1);
            Product product = new Product { Name = "Леденец", Price = 65, ProducerId = 1, CategoryId = 1,Description="Клубничный топчик" };
            Product product1 = new Product { Name = "Хлеб", Price = 240, ProducerId = 2, CategoryId = 2,Description="Сдобный горячий спечи" };
            db.Product.Add(product);
            db.Product.Add(product1);
            db.SaveChanges();
        }
    }
}