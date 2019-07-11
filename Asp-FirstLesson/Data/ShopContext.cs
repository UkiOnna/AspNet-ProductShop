namespace Asp_FirstLesson
{
    using Asp_FirstLesson.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShopContext : DbContext
    {
        public ShopContext()
          : base("name=ShopContext")
        {
        }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role{ get; set; }
      

        public void FillBd(ShopContext db)
        {
            Role role = new Role { Name = "Creator" };
            Role role1 = new Role { Name = "Admin" };
            Role role2 = new Role { Name = "User" };
            db.Role.Add(role);
            db.Role.Add(role1);
            db.Role.Add(role2);
            Producer producer = new Producer { Name = "Хлебозавод #1" };
            Producer producer1 = new Producer { Name = "Молокозавод #1" };
            db.Producer.Add(producer);
            db.Producer.Add(producer1);
            Category category = new Category { Id = 1, Name = "Сладости" };
            db.Category.Add(category);
            Product product = new Product { Name = "Хлеб", Price = 65, ProducerId = 1,CategoryId=1};
            Product product1 = new Product { Name = "Молоко", Price = 240, ProducerId = 2,CategoryId=1 };
            db.Product.Add(product);
            db.Product.Add(product1);
            User user = new User { Name = "Leha", Login = "Leha90", Password = "123456", RoleId = 1 };
            User user1 = new User { Name = "Gena", Login = "GenAdy", Password = "genka000", RoleId = 2 };
            User user2 = new User { Name = "Miha", Login = "mehanik89", Password = "meh101", RoleId = 3 };
            db.User.Add(user);
            db.User.Add(user1);
            db.User.Add(user2);
            db.SaveChanges();
        }
    }
  
}