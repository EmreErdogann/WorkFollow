using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkFollow.Entities.Concrete
{
    public class User : IdentityUser<int>
    {
        
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Picture { get; set; } = "default.png";
        public List<Taskk> Tasks { get; set; }
    }
}
