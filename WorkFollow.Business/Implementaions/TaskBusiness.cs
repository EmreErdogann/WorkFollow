using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkFollow.Business.Interfaces;
using WorkFollow.Business.Utilities;
using WorkFollow.Core.DTos;
using WorkFollow.Data.Interfaces;
using WorkFollow.Entities.Concrete;


namespace WorkFollow.Business.Implementaions
{

    public class TaskBusiness : ITaskBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Result<TaskDto> Create(TaskDto model)
        {
            if (model != null)
            {

                try
                {
                    var task = _mapper.Map<TaskDto, Taskk>(model);
                    task.CreatedDate = DateTime.Now;
                    task.IsDeleted = true;
                    _unitOfWork.taskRepository.Add(task);
                    _unitOfWork.Save();
                    return new Result<TaskDto>(true, $"{model.Name} adlı görev başarı ile eklenmiştir");
                }
                catch (Exception ex)
                {
                    return new Result<TaskDto>(false, "Kayıt Gerçekleştirilirken Hata Oluştu" + ex.Message.ToString());
                }
            }
            return new Result<TaskDto>(false, "Parametre Olarak Geçilen Data Boş Olamaz");
        }

        public Result<TaskDto> Delete(int id)
        {
            var data = _unitOfWork.taskRepository.Get(id);
            if (data != null)
            {
                data.IsDeleted = false;
                _unitOfWork.taskRepository.Update(data);
                _unitOfWork.Save();
                return new Result<TaskDto>(true, "Kayıt Başarı İle Gerçekleşti");
            }
            return new Result<TaskDto>(false, "Kayıt Gerçekleştirilirken Hata Oluştu");
        }

        public Result<List<TaskDto>> GetAll()
        {

            var data = _unitOfWork.taskRepository.GetAll(null, x => x.Urgency).ToList();
            var task = _mapper.Map<List<Taskk>, List<TaskDto>>(data);
            return new Result<List<TaskDto>>(true, "Kayıt Bulundu", task);
        }

        public Result<List<TaskDto>> GetAllDeleted()
        {
            var data = _unitOfWork.taskRepository.GetAll(x => x.IsDeleted == true, includeProperties: x => x.Urgency).ToList();

            var task = _mapper.Map<List<Taskk>, List<TaskDto>>(data);
            return new Result<List<TaskDto>>(true, "Kayıt Bulundu", task);
        }

        public Result<TaskDto> GetById(int id)
        {
            var data = _unitOfWork.taskRepository.Get(id);
            if (data != null)
            {
                var task = _mapper.Map<Taskk, TaskDto>(data);
                return new Result<TaskDto>(true, "Kayıt Bulundu", task);
            }
            else
                return new Result<TaskDto>(false, "Kayıt Bulunamadı");
        }

        public Result<TaskDto> GetReportId(int id)
        {
            var data = _unitOfWork.taskRepository.GetAll(x => x.Id == id, x => x.Report, x => x.User).FirstOrDefault();
            if (data == null)
            {
                return new Result<TaskDto>(false, "Kayıt Bulunamadı!");
            }

            var task = _mapper.Map<Taskk, TaskDto>(data);
            return new Result<TaskDto>(true, "Kayıt Bulundu", task);
        }

        public int GetTaskUser(int id)
        {
            return _unitOfWork.taskRepository.GetTaskUser(id);
        }

        public Result<TaskDto> GetUrcenyId(int id)
        {

            var data = _unitOfWork.taskRepository.GetAll(x => x.Id == id, x => x.Urgency, x => x.Report).FirstOrDefault();
            if (data == null)
            {
                return new Result<TaskDto>(false, "Kayıt Bulunamadı!");
            }

            var task = _mapper.Map<Taskk, TaskDto>(data);
            return new Result<TaskDto>(true, "Kayıt Bulundu", task);
        }

        public Result<List<TaskDto>> GetUserId(int userId)
        {
            var data = _unitOfWork.taskRepository.GetUserId(userId).ToList();
            if (data == null)
            {
                return new Result<List<TaskDto>>(false, "Kayıt Bulunamadı!");
            }
            var task = _mapper.Map<List<Taskk>, List<TaskDto>>(data);
            return new Result<List<TaskDto>>(true, "Kayıt Bulundu", task);
        }

        public Result<TaskDto> Update(TaskDto model)
        {
            if (model != null)
            {
                try
                {
                    var task = _mapper.Map<TaskDto, Taskk>(model);
                    task.UpdatedDate = DateTime.Now;
                    task.IsDeleted = true;
                    _unitOfWork.taskRepository.Update(task);
                    _unitOfWork.Save();
                    return new Result<TaskDto>(true, $"{model.Name} adlı görev başarı ile güncellenmiştir");
                }
                catch (Exception ex)
                {
                    return new Result<TaskDto>(false, "Kayıt Gerçekleştirilirken Hata Oluştu" + ex.Message.ToString());

                }
            }
            else
                return new Result<TaskDto>(false, "Parametre Olarak Geçilen Data Boş Olamaz");
        }

        public Result<List<TaskDto>> UserReportUrgencyGetAll(int userId = 0)
        {
            List<Taskk> data;
            if (userId > 0)
                data = _unitOfWork.taskRepository.GetAll(x => x.UserId == userId && x.IsDeleted == true && x.Case == false, x => x.Urgency, x => x.Report, x => x.User).ToList();
            else
                data = _unitOfWork.taskRepository.GetAll(predicate: x => x.IsDeleted == true, x => x.Urgency, x => x.Report, x => x.User).ToList();
            var task = _mapper.Map<List<Taskk>, List<TaskDto>>(data);
            return new Result<List<TaskDto>>(true, "Kayıt Bulundu", task);
        }

        public Result<List<TaskDto>> UserReportUrgencyGetAllCompleted(int userId = 0)
        {
            List<Taskk> data;
            if (userId > 0)
                data = _unitOfWork.taskRepository.GetAll(x => x.UserId == userId && x.IsDeleted == true && x.Case == true, x => x.Urgency, x => x.Report, x => x.User).ToList();
            else
                data = _unitOfWork.taskRepository.GetAll(predicate: x => x.IsDeleted == true, x => x.Urgency, x => x.Report, x => x.User).ToList();
            var task = _mapper.Map<List<Taskk>, List<TaskDto>>(data);
            return new Result<List<TaskDto>>(true, "Kayıt Bulundu", task);

        }
    }
}
