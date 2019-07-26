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
    public class ProductController : ApiController
    {
        private readonly IRepository<Product> ProductRepository = new ProductRepository();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(ProductRepository.GetAll().ToList());
        }

        [HttpDelete]
        public void Delete(int id)
        {
            ProductRepository.Delete(id);
        }

        [HttpPost]
        public void Add([FromBody]Product product)
        {
            ProductRepository.Add(product);
        }
        [HttpPut]
        public void Edit([FromBody]Product item)
        {
            ProductRepository.Edit(item);
        }

        public IHttpActionResult GetItem(int id)
        {
            return Json(ProductRepository.GetItem(id));
        }

    }
}
