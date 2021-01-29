using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Data.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        List<User> GetAdmın();

    }
}
