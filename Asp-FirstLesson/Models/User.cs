using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_FirstLesson.Models
{
    public class User:Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Role role { get; set; }
    }
}