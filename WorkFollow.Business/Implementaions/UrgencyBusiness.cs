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
    public class UrgencyBusiness : IUrgencyBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UrgencyBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Result<UrgencyDto> Create(UrgencyDto model)
        {
            if (model != null)
            {
                try
                {
                    var urgency = _mapper.Map<UrgencyDto, Urgency>(model);
                    urgency.CreatedDate = DateTime.Now;
                    urgency.IsDeleted = true;
                    _unitOfWork.urgencyRepository.Add(urgency);
                    _unitOfWork.Save();
                    return new Result<UrgencyDto>(true, "Kayıt Başarı İle Gerçekleşti");
                }
                catch (Exception ex)
                {
                    return new Result<UrgencyDto>(false, "Kayıt Gerçekleştirilirken Hata Oluştu" + ex.Message.ToString());
                }
            }
            else
                return new Result<UrgencyDto>(false, "Parametre Olarak Geçilen Data Boş Olamaz");
        }

        public Result<UrgencyDto> Delete(int id)
        {
            var data = _unitOfWork.urgencyRepository.Get(id);
            if (data != null)
            {
                data.IsDeleted = false;
                _unitOfWork.urgencyRepository.Update(data);
                _unitOfWork.Save();
                return new Result<UrgencyDto>(true, "Kayıt Başarı İle Gerçekleşti");

            }
            else
                return new Result<UrgencyDto>(false, "Kayıt Gerçekleştirilirken Hata Oluştu");
        }

        public Result<List<UrgencyDto>> GetAll()
        {
            var data = _unitOfWork.urgencyRepository.GetAll().ToList();

            var urgency = _mapper.Map<List<Urgency>, List<UrgencyDto>>(data);
            return new Result<List<UrgencyDto>>(true, "Kayıt Bulundu", urgency);
        }

        public Result<List<UrgencyDto>> GetAllDeleted()
        {
            var data = _unitOfWork.urgencyRepository.GetAll(x => x.IsDeleted == true).ToList();

            var urgency = _mapper.Map<List<Urgency>, List<UrgencyDto>>(data);
            return new Result<List<UrgencyDto>>(true, "Kayıt Bulundu", urgency);
        }

        public Result<UrgencyDto> GetById(int id)
        {
            var data = _unitOfWork.urgencyRepository.Get(id);
            if (data != null)
            {
                var urgency = _mapper.Map<Urgency, UrgencyDto>(data);
                return new Result<UrgencyDto>(true, "Kayıt Bulundu", urgency);
            }
            else
                return new Result<UrgencyDto>(false, "Kayıt Bulunamadı");
        }

        public Result<UrgencyDto> Update(UrgencyDto model)
        {
            if (model != null)
            {
                try
                {
                    var urgency = _mapper.Map<UrgencyDto, Urgency>(model);
                    urgency.UpdatedDate = DateTime.Now;
                    urgency.IsDeleted = true;
                    _unitOfWork.urgencyRepository.Update(urgency);
                    _unitOfWork.Save();
                    return new Result<UrgencyDto>(true, "Kayıt Başarı İle Gerçekleşti");
                }
                catch (Exception ex)
                {
                    return new Result<UrgencyDto>(false, "Kayıt Gerçekleştirilirken Hata Oluştu" + ex.Message.ToString());

                }
            }
            else
                return new Result<UrgencyDto>(false, "Parametre Olarak Geçilen Data Boş Olamaz");
        }
    }
}
