using AutoMapper;
using ldtiep.be.BL.Dto;
using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Model;

namespace ldtiep.be.BL
{
    /// <summary>
    /// Class dành cho automapper 
    /// </summary>
    /// Author: LeDucTiep (07/06/2023)
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeCreateDto>();
            CreateMap<EmployeeCreateDto, EmployeeDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeDto, EmployeeCreateDto>();
            CreateMap<EmployeeUpdateDto, Employee>();
            CreateMap<EmployeeUpdateDto, EmployeeDto>();
            CreateMap<EmployeeDto, EmployeeUpdateDto>();
            CreateMap<Employee, EmployeeUpdateDto>();
            CreateMap<BasePage<Employee>, BasePage<EmployeeDto>>();
        }
    }
}
