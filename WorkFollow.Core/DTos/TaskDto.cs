using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Core.DTos
{
    public class TaskDto : BaseDto
    {
        [DisplayName("Ad ")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez ")]
        [MaxLength(250, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır ")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır ")]
        public string Name { get; set; }

        [DisplayName("Açıklama ")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez ")]
        public string Explanation { get; set; }

        [DisplayName("Aciliyet Seçiniz ")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez ")]
        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public List<Report> Report { get; set; }

        public bool Case { get; set; }

     
    }
}
