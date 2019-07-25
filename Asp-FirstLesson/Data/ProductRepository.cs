using Asp_FirstLesson.Interfaces;
using Asp_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.Data
{
    public class ProductRepository : IRepository<Product>
    {
        ShopContext db=new ShopContext();
        public void Add(Product item)
        {
            db.Product.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = db.Product.FirstOrDefault(s => s.Id == id);
            if (product != null)
            {
                db.Product.Remove(product);
                db.SaveChanges();
            }
            
        }

        public void Edit(Product item)
        {
            var product1 = db.Product.FirstOrDefault(s => s.Id == item.Id);
            if (product1 != null)
            {
                product1.Name = item.Name;
                product1.Price = item.Price;
                product1.ProducerId = item.ProducerId;
                product1.CategoryId = item.CategoryId;
                db.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Product;
        }

        public Product GetItem(int id)
        {
            var product = db.Product.FirstOrDefault(s => s.Id == id);
            return product;

        }
    }
}