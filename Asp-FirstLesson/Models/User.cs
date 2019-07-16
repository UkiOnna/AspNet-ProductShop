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
        [Required(ErrorMessage ="Логин обязательное поле")]
        [MinLength(3,ErrorMessage ="Логин состоять как минимум из 3 символов")]
        [RegularExpression("^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9]{2,9}$", ErrorMessage = "Логин не должен содержать спец. символы и должен иметь определенную длину")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль обязательное поле")]
        [MinLength(4, ErrorMessage = "Пароль должен состоять как минимум из 4 символов")]
        public string Password { get; set; }
        [ForeignKey("Role")]
        [Required]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}