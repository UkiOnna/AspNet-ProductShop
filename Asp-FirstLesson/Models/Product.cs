using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.Models
{
    public class Product:Entity
    {
        [ForeignKey("Producer")]
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
        [Required]
        public double Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Description { get; set; }
    }
}