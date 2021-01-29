using System;
using System.Collections.Generic;
using System.Text;

namespace WorkFollow.Entities.Abstract
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime UpdatedDate { get; set; }


    }
}
