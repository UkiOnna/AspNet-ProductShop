using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.Models
{
    public class Basket
    {
        [Required]
        [Key]
        public int Id { get; set; }
        List<Dictionary<int, int>> Items { get; set; }
    }
}