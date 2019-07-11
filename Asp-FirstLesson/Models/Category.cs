using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.Models
{
    public class Category:Entity
    {
        public virtual IEnumerable<Product> Products { get; set; }
    }
}