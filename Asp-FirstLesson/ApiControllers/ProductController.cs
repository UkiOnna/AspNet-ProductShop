using Asp_FirstLesson.Data;
using Asp_FirstLesson.Interfaces;
using Asp_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Asp_FirstLesson.ApiControllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private readonly IRepository<Product> ProductRepository=new ProductRepository();

        [Route("GetAllItems")]
        public IHttpActionResult GetAllItems()
        {
            return Json(ProductRepository.GetAll().ToList());
        }
        [Route("Delete")]
        public void Delete(int id)
        {
            ProductRepository.Delete(id);
        }
        [Route("Add")]
        public void Add(Product product)
        {
            ProductRepository.Add(product);
        }
        [Route("Edit")]
        public void Edit(Product item)
        {
            ProductRepository.Edit(item);
        }
        [Route("GetItem")]
        public IHttpActionResult GetItem(int id)
        {
            return Json(ProductRepository.GetItem(id));
        }

    }
}
