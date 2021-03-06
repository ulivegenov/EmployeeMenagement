﻿namespace EmployeeManagement.Web.Models.Profiles
{
    using AutoMapper;

    using EmployeeManagement.Models;

    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeFormModel>()
                .ForMember(dest => dest.ConfirmEmail,
                           opt => opt.MapFrom(src => src.Email));
            CreateMap<EmployeeFormModel, Employee>();
        }
    }
}
