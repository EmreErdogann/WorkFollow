using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkFollow.Data.DataContext;
using WorkFollow.Data.Interfaces;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Data.Implementaions
{
    public class EfTaskRepository : EfRepository<Taskk>, ITaskRepository
    {
        private readonly WorkFollowDataContext _dbContext;
        public EfTaskRepository(WorkFollowDataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetTaskUser(int id)
        {
            return _dbContext.Task.Count(ı => ı.UserId == id && ı.Case == true);
        }

        public List<Taskk> GetUserId(int userId)
        {
            return _dbContext.Task.Where(ı => ı.UserId == userId).ToList();
        }
    }
}
