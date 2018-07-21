using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TokenDemo.Model
{
    public class LoginModel
    {
        [Required( ErrorMessage="username isrequired")]
        public string Username { get; set; }

        [Required(ErrorMessage = "password isrequired")]
        public string Password { get; set; }
    }
}
