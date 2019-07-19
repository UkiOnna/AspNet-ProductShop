﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}