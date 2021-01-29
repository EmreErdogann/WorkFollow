using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Data.DataContext;
using WorkFollow.Data.Interfaces;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Data.Implementaions
{
    public class EfUrgencyRepository : EfRepository<Urgency>, IUrgencyRepository
    {
        private readonly WorkFollowDataContext _dbContext;
        public EfUrgencyRepository(WorkFollowDataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
