using Asp_FirstLesson.Interfaces;
using Asp_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.Data
{
    public class UserRepository : IRepository<User>
    {
        ShopContext db;

        public UserRepository(ShopContext db)
        {
            this.db = db;
        }
        public void Add(User item)
        {
            db.User.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = db.User.FirstOrDefault(s => s.Id == id);
            if (product != null)
            {
                db.User.Remove(product);
                db.SaveChanges();
            }
        }

        public void Edit(User item)
        {
            var product1 = db.User.FirstOrDefault(s => s.Id == item.Id);
            if (product1 != null)
            {
                product1.Name = item.Name;
                product1.Login = item.Login;
                product1.Password = item.Password;
                product1.RoleId = item.RoleId;
                db.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return db.User;
        }

        public User GetItem(int id)
        {
            var product = db.User.FirstOrDefault(s => s.Id == id);
            return product;
        }
    }
}