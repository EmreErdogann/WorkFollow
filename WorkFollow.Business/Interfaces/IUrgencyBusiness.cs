using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Business.Utilities;
using WorkFollow.Core.DTos;

namespace WorkFollow.Business.Interfaces
{
    public interface IUrgencyBusiness
    {
        Result<List<UrgencyDto>> GetAll();
        Result<List<UrgencyDto>> GetAllDeleted();
        Result<UrgencyDto> Create(UrgencyDto model);
        Result<UrgencyDto> GetById(int id);
        Result<UrgencyDto> Update(UrgencyDto model);
        Result<UrgencyDto> Delete(int id);
    }
}
