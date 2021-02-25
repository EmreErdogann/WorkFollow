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
    public class ReportBusiness : IReportBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReportBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Result<ReportDto> Create(ReportDto model)
        {
            if (model != null)
            {

                try
                {
                    var report = _mapper.Map<ReportDto, Report>(model);
                    report.CreatedDate = DateTime.Now;
                    report.IsDeleted = true;
                    _unitOfWork.reportRepository.Add(report);
                    _unitOfWork.Save();
                    return new Result<ReportDto>(true, $"{model.Detail} başlıklı görev ile bilgilendirme başarı ile kaydedildi");
                }
                catch (Exception ex)
                {
                    return new Result<ReportDto>(false, "Kayıt Gerçekleştirilirken Hata Oluştu" + ex.Message.ToString());
                }
            }
            return new Result<ReportDto>(false, "Parametre Olarak Geçilen Data Boş Olamaz");
        }

        public Result<ReportDto> Delete(int id)
        {
            var data = _unitOfWork.reportRepository.Get(id);
            if (data != null)
            {
                data.IsDeleted = false;
                _unitOfWork.reportRepository.Update(data);
                _unitOfWork.Save();
                return new Result<ReportDto>(true, "Kayıt Başarı İle Gerçekleşti");
            }
            return new Result<ReportDto>(false, "Kayıt Gerçekleştirilirken Hata Oluştu");
        }

        public Result<List<ReportDto>> GetAll()
        {
            var data = _unitOfWork.reportRepository.GetAll(null, x => x.Task).ToList();
            var report = _mapper.Map<List<Report>, List<ReportDto>>(data);
            return new Result<List<ReportDto>>(true, "Kayıt Bulundu", report);
        }

        public Result<List<ReportDto>> GetAllDeleted()
        {
            var data = _unitOfWork.reportRepository.GetAll(x => x.IsDeleted == true, includeProperties: x => x.Task).ToList();

            var report = _mapper.Map<List<Report>, List<ReportDto>>(data);
            return new Result<List<ReportDto>>(true, "Kayıt Bulundu", report);
        }

        public Result<ReportDto> GetById(int id)
        {
            var data = _unitOfWork.reportRepository.Get(id);
            if (data != null)
            {
                var report = _mapper.Map<Report, ReportDto>(data);
                return new Result<ReportDto>(true, "Kayıt Bulundu", report);
            }
            else
                return new Result<ReportDto>(false, "Kayıt Bulunamadı");
        }

        public int GetReportNumberUserId(int id)
        {
            return _unitOfWork.reportRepository.GetReportNumberUserId(id);

        }

        public Result<ReportDto> GetTaskId(int id)
        {
            var data = _unitOfWork.reportRepository.GetTaskId(id);
            if (data == null)
            {
                return new Result<ReportDto>(false, "Kayıt Bulunamadı!");
            }

            var report = _mapper.Map<Report, ReportDto>(data);
            return new Result<ReportDto>(true, "Kayıt Bulundu", report);
        }

        public Result<ReportDto> Update(ReportDto model)
        {
            if (model != null)
            {
                try
                {
                    var report = _mapper.Map<ReportDto, Report>(model);
                    report.UpdatedDate = DateTime.Now;
                    report.IsDeleted = true;
                    _unitOfWork.reportRepository.Update(report);
                    _unitOfWork.Save();
                    return new Result<ReportDto>(true, "Kayıt Başarı İle Gerçekleşti");
                }
                catch (Exception ex)
                {
                    return new Result<ReportDto>(false, "Kayıt Gerçekleştirilirken Hata Oluştu" + ex.Message.ToString());

                }
            }
            else
                return new Result<ReportDto>(false, "Parametre Olarak Geçilen Data Boş Olamaz");
        }
    }
}
