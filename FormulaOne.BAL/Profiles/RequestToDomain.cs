using AutoMapper;
using FormulaOne.BAL.DTOS.Requests;
using FormulaOne.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Profiles
{
    internal class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateDriverAchievementDto, Achievement>().ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(src => DateTime.Now)
                ).ForMember(
                    dest => dest.UpdatedDate,
                    opt => opt.MapFrom(src => DateTime.Now)
                ).ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => 1)
                );

            CreateMap<UpdateDriverAchievementDto, Achievement>().ForMember(
                   dest => dest.UpdatedDate,
                   opt => opt.MapFrom(src => DateTime.Now)
                   ).ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => 1)
                ).ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.AchievementId)
                );

            CreateMap<CreateDriverDto, Driver>().ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(src => DateTime.Now)
                ).ForMember(
                     dest => dest.UpdatedDate,
                     opt => opt.MapFrom(src => DateTime.Now)
                ).ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => 1)
                );

            CreateMap<UpdateDriverDto, Driver>().ForMember(
                     dest => dest.UpdatedDate,
                     opt => opt.MapFrom(src => DateTime.Now)
                ).ForMember(
                     dest => dest.Id,
                     opt => opt.MapFrom(src => src.DriverId)
                ).ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => 1)
                );
        }
    }
}
