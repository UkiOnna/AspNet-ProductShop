using Asp_FirstLesson.Interfaces;
using Asp_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.Data
{
    public class ProducerRepository : IRepository<Producer>
    {
        ShopContext db;

        public ProducerRepository(ShopContext db)
        {
            this.db = db;
        }
        public void Add(Producer item)
        {
            db.Producer.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = db.Producer.FirstOrDefault(s => s.Id == id);
            if (product != null)
            {
                db.Producer.Remove(product);
                db.SaveChanges();
            }
        }

        public void Edit(Producer item)
        {
            var product1 = db.Producer.FirstOrDefault(s => s.Id == item.Id);
            if (product1 != null)
            {
                product1.Name = item.Name;
                db.SaveChanges();
            }
        }

        public IEnumerable<Producer> GetAll()
        {
            return db.Producer;
        }

        public Producer GetItem(int id)
        {
            var product = db.Producer.FirstOrDefault(s => s.Id == id);
            return product;
        }
    }
}