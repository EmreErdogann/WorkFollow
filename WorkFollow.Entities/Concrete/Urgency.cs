using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Entities.Abstract;

namespace WorkFollow.Entities.Concrete
{
    public class Urgency : BaseEntity
    {
        public string Definition { get; set; }
        public List<Taskk> Tasks { get; set; }
    }
}
