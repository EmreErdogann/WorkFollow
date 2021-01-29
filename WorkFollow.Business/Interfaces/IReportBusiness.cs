using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Business.Utilities;
using WorkFollow.Core.DTos;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Business.Interfaces
{
    public interface IReportBusiness
    {
        Result<List<ReportDto>> GetAll();
        Result<List<ReportDto>> GetAllDeleted();
        Result<ReportDto> Create(ReportDto model);
        Result<ReportDto> GetById(int id);
        Result<ReportDto> Update(ReportDto model);
        Result<ReportDto> Delete(int id);
        Result<ReportDto> GetTaskId(int id);
        int GetReportNumberUserId(int id);
    }
}
