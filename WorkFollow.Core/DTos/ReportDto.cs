using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Core.DTos
{
    public class ReportDto : BaseDto
    {
        [DisplayName("Tanım ")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez ")]
        public string Definition { get; set; }

        [DisplayName("Detay ")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez ")]
        public string Detail { get; set; }
        public int TaskId { get; set; }
        public Taskk Task { get; set; }
    }
}
