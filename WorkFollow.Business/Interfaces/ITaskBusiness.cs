using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Business.Utilities;
using WorkFollow.Core.DTos;

namespace WorkFollow.Business.Interfaces
{
    public interface ITaskBusiness
    {
        Result<List<TaskDto>> GetAll();
        Result<List<TaskDto>> GetAllDeleted();
        Result<TaskDto> Create(TaskDto model);
        Result<TaskDto> GetById(int id);
        Result<TaskDto> Update(TaskDto model);
        Result<TaskDto> Delete(int id);
        Result<List<TaskDto>> UserReportUrgencyGetAll(int userId = 0);
        Result<TaskDto> GetUrcenyId(int id);
        Result<List<TaskDto>> GetUserId(int userId);
        Result<TaskDto> GetReportId(int id);
        Result<List<TaskDto>> UserReportUrgencyGetAllCompleted(int userId = 0);
        int GetTaskUser(int id);
    }
}
