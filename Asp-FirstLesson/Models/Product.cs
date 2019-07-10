using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.Models
{
    public class Product:Entity
    {
        public double Price { get; set; }
        public Producer Producer { get; set; }
    }
}