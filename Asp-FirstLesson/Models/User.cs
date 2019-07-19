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
        [ForeignKey("Role")]
        [Range(1, int.MaxValue)]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}