using Asp_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.Data
{
    public class ShopContextInitializer:CreateDatabaseIfNotExists<ShopContext>
    {
        protected override void Seed(ShopContext db)
        {
            Role role = new Role { Name = "User" };
            Role role1 = new Role { Name = "Admin" };
            db.Role.Add(role);
            db.Role.Add(role1);
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