using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen alanı doldurunuz.")]
        public string NameSurname { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen alanı doldurunuz.")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifreler eşleşmelidir. ")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Lütfen alanı doldurunuz.")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen alanı doldurunuz.")]
        public string UserName { get; set; }
    }
}
