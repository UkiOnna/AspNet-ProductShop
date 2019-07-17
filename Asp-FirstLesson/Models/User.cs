using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.Models
{
    public class User:Entity
    {
        [RegularExpression("^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9]{2,9}$", ErrorMessage = "Логин не должен содержать спец. символы и должен иметь определенную длину")]
        public string Login { get; set; }
        public string Password { get; set; }
        [ForeignKey("Role")]
        [Range(1, int.MaxValue)]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}