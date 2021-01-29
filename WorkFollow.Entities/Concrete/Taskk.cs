using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Entities.Abstract;

namespace WorkFollow.Entities.Concrete
{
    public class Taskk : BaseEntity
    {
        public string Name { get; set; }
        public string Explanation { get; set; }
        public bool Case { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }

        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }

        public List<Report> Report { get; set; }
    }
}
