using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Core.DTos;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Core.AutoMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
           
            CreateMap<Urgency, UrgencyDto>().ReverseMap();
            CreateMap<Taskk,TaskDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Report, ReportDto>().ReverseMap();
        }
    }
}
