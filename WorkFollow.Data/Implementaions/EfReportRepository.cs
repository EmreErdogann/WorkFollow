using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkFollow.Data.DataContext;
using WorkFollow.Data.Interfaces;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Data.Implementaions
{
    public class EfReportRepository : EfRepository<Report>, IReportRepository
    {
        private readonly WorkFollowDataContext _dbContext;
        public EfReportRepository(WorkFollowDataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetReportNumberUserId(int id)
        {
            var result = _dbContext.Task.Include(ı => ı.Report).Where(ı => ı.UserId == id);
            return result.SelectMany(ı => ı.Report).Count();
        }

        public Report GetTaskId(int id)
        {
            return _dbContext.Report.Include(ı => ı.Task).ThenInclude(ı => ı.Urgency).Where(ı => ı.Id == id).FirstOrDefault();
        }
    }
}
