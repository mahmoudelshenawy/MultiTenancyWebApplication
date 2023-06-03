using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Entities;

namespace Core.ProfilesMapping
{
    internal class EmployeeMapping : Profile
    {
        public EmployeeMapping()
        {
            CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name))
                .ForMember(dest => dest.DateOfHiring, source => source.MapFrom(src => src.DateOfHiring))
                .ForMember(dest => dest.DepartmentId, source => source.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.Salary, source => source.MapFrom(src => src.Salary))
                .ReverseMap();
        }
    }
}
