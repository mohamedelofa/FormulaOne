using AutoMapper;
using FormulaOne.BAL.DTOS.Responses;
using FormulaOne.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.BAL.Profiles
{
    internal class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Achievement, DriverAchievementResponseDto>().ForMember(dest => dest.AchievementId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Driver, DriverResponseDto>().ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                ).ForMember(
                    dest => dest.DriverId,
                    opt => opt.MapFrom(src => src.Id)
                );
        }
    }
}
