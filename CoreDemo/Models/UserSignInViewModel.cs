using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen alanı doldurunuz.")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen alanı doldurunuz.")]
        public string password { get; set; }
    }
}
