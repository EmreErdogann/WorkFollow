using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Data.Interfaces
{
    public interface IReportRepository : IRepository<Report>
    {
        Report GetTaskId(int id);
        int GetReportNumberUserId(int id);
    }
}
