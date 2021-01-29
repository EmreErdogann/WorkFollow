using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkFollow.Core.DTos
{
    public class UserDto : BaseDto
    {
        [DisplayName("Ad ")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez ")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır ")]
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır ")]
        public string Name { get; set; }

        [DisplayName("Soyad ")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez ")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır ")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır ")]
        public string SurName { get; set; }

        [DisplayName("Resim ")]
        public string Picture { get; set; }

        [DisplayName("Email ")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez ")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-posta geçerli değil")]
        public string Email { get; set; }
    }
}
