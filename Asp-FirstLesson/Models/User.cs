using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.Models
{
    public class User:IdentityUser
    {
        [Required]
        public double Wallet { get; set; }
        [Required]
        public int BasketId { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }//ПОДСТАВА
        [Required]
        public string Country { get; set; }
    }
}