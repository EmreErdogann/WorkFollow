using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkFollow.Core.DTos
{
    public class UrgencyDto : BaseDto
    {
        [DisplayName("Tanım")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez ")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır ")]
        [MinLength(4, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır ")]
        public string Definition { get; set; }
        
    }
}
