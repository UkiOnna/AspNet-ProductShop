using Asp_FirstLesson.Data;
using Asp_FirstLesson.Interfaces;
using Asp_FirstLesson.Models;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.App_Start
{
    public class NinjectRegistrator : NinjectModule
    {
        public override void Load()
        {
            Bind<ShopContext>().To<ShopContext>();

            Bind<IRepository<Product>>().To<ProductRepository>();
            Bind<IRepository<Category>>().To<CategoryRepository>();
            Bind<IRepository<Producer>>().To<ProducerRepository>();
        }
    }
}