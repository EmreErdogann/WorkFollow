using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Data.Interfaces
{
    public interface ITaskRepository : IRepository<Taskk>
    {

        List<Taskk> GetUserId(int userId);
        int GetTaskUser(int id);
        
    }
}
