using Asp_FirstLesson.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.ViewModels
{
    public class EditUserViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required(ErrorMessage = "Логин обязательное поле")]
        [MinLength(3, ErrorMessage = "Логин состоять как минимум из 3 символов")]
        [RegularExpression("^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9]{2,9}$", ErrorMessage = "Логин не должен содержать спец. символы и должен иметь определенную длину")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string Email { get; set; }
        public string RoleId { get; set; }

        public EditUserViewModel()
        {

        }

        public EditUserViewModel(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            RoleId = user.Roles.First().RoleId;
            Email = user.Email;
        }

    }

}