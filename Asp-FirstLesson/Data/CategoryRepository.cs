using Asp_FirstLesson.Interfaces;
using Asp_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.Data
{
    public class CategoryRepository : IRepository<Category>
    {
        ShopContext db;

        public CategoryRepository(ShopContext db)
        {
            this.db = db;
        }
        public void Add(Category item)
        {
            db.Category.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = db.Category.FirstOrDefault(s => s.Id == id);
            if (product != null)
            {
                db.Category.Remove(product);
                db.SaveChanges();
            }
        }

        public void Edit(Category item)
        {
            var product1 = db.Category.FirstOrDefault(s => s.Id == item.Id);
            if (product1 != null)
            {
                product1.Name = item.Name;
                db.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Category;
        }

        public Category GetItem(int id)
        {
            var product = db.Category.FirstOrDefault(s => s.Id == id);
            return product;
        }
    }
}