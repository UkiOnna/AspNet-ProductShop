namespace Asp_FirstLesson
{
    using Asp_FirstLesson.Data;
    using Asp_FirstLesson.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShopContext : DbContext
    {
        public ShopContext()
          : base("name=ShopContext")
        {
            Database.SetInitializer<ShopContext>(new ShopContextInitializer());
        }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role{ get; set; }
    }
  
}