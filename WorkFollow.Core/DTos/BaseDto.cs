using System;
using System.Collections.Generic;
using System.Text;

namespace WorkFollow.Core.DTos
{
    public class BaseDto
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
