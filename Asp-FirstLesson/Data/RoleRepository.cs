using Asp_FirstLesson.Interfaces;
using Asp_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.Data
{
    public class RoleRepository: IRepository<Role>
    {
        ShopContext db;

        public RoleRepository(ShopContext db)
        {
            this.db = db;
        }
        public void Add(Role item)
        {
            db.Role.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = db.Role.FirstOrDefault(s => s.Id == id);
            if (product != null)
            {
                db.Role.Remove(product);
                db.SaveChanges();
            }
        }

        public void Edit(Role item)
        {
            var product1 = db.Role.FirstOrDefault(s => s.Id == item.Id);
            if (product1 != null)
            {
                product1.Name = item.Name;
                db.SaveChanges();
            }
        }

        public IEnumerable<Role> GetAll()
        {
            return db.Role;
        }

        public Role GetItem(int id)
        {
            var product = db.Role.FirstOrDefault(s => s.Id == id);
            return product;
        }
    }
}