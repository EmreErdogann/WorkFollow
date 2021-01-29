using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Business.Utilities;
using WorkFollow.Core.DTos;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Business.Interfaces
{
    public interface IUserBusiness
    {
        Result<List<UserDto>> GetAdmın();

    }
}
