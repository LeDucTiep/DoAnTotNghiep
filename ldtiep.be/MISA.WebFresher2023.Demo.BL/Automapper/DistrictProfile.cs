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
    public class DistrictProfile : Profile
    {
        public DistrictProfile()
        {
            CreateMap<District, DistrictDto>();
            CreateMap<DistrictDto, District>();
            CreateMap<District, DistrictCreateDto>();
            CreateMap<DistrictCreateDto, DistrictDto>();
            CreateMap<DistrictCreateDto, District>();
            CreateMap<DistrictDto, DistrictCreateDto>();
            CreateMap<DistrictUpdateDto, District>();
            CreateMap<DistrictUpdateDto, DistrictDto>();
            CreateMap<DistrictDto, DistrictUpdateDto>();
            CreateMap<District, DistrictUpdateDto>();
            CreateMap<BasePage<District>, BasePage<DistrictDto>>();
        }
    }
}
