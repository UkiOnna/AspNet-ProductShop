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
        [Required(ErrorMessage = "Логин обязательное поле")]
        [MinLength(3, ErrorMessage = "Логин состоять как минимум из 3 символов")]
        [RegularExpression("^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9]{2,9}$", ErrorMessage = "Логин не должен содержать спец. символы и должен иметь определенную длину")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль обязательное поле")]
        [MinLength(4, ErrorMessage = "Пароль должен состоять как минимум из 4 символов")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string Email { get; set; }
        public string SecondPassword { get; set; }

        public void SetFields(User user)
        {
            Login = user.UserName;
            Password = user.PasswordHash;
        }

        public User GetUser()
        {
            return new User {  UserName = Login, PasswordHash = Password };
        }
    }
}