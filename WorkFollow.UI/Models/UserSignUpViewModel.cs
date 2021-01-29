using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFollow.UI.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Kullanıcı Adı ")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string UserName { get; set; }

        [Display(Name = "Şifre ")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar ")]
        [Compare("Password", ErrorMessage = "Parolalar eşlemiyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Ad ")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string Name { get; set; }

        [Display(Name = "Soyad ")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string SurName { get; set; }

        [Display(Name = "Email ")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        [EmailAddress(ErrorMessage = "E-posta alanı, geçerli bir e-posta adresi değil.")]
        public string Email { get; set; }

    }
}
