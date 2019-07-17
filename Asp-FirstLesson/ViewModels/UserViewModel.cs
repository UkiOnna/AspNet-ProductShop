using Asp_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Поле имя должно быть заполнено")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Логин обязательное поле")]
        [MinLength(3, ErrorMessage = "Логин состоять как минимум из 3 символов")]
        [RegularExpression("^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9]{2,9}$", ErrorMessage = "Логин не должен содержать спец. символы и должен иметь определенную длину")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль обязательное поле")]
        [MinLength(4, ErrorMessage = "Пароль должен состоять как минимум из 4 символов")]
        public string Password { get; set; }
        [Range(1, int.MaxValue)]
        public int RoleId { get; set; }
        public string SecondPassword { get; set; }

        public void SetFields(User user)
        {
            Login = user.Login;
            Password = user.Password;
            RoleId = user.RoleId;
        }

        public User GetUser()
        {
            return new User { Name = Name, Login = Login, Password = Password, RoleId = RoleId };
        }
    }
}