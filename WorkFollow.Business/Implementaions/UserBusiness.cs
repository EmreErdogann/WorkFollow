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
    public class UserBusiness : IUserBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Result<List<UserDto>> GetAdmın()
        {
            var data = _unitOfWork.userRepository.GetAdmın().ToList();

            var urgency = _mapper.Map<List<User>, List<UserDto>>(data);
            //Burda Birtek Null Kontrolü Yapabilirsin
            if (urgency == null)
            {
                return new Result<List<UserDto>>(false, "Kayıt Bulunamadı!");
            }
            return new Result<List<UserDto>>(true, "Kayıt Bulundu", urgency);
        }
    }
}
