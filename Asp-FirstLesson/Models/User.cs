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
        public int BasketId { get; set; }
        public DateTime BirthDate { get; set; }//ПОДСТАВА
    }
}