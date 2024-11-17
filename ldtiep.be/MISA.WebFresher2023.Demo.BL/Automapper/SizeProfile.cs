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
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<Size, SizeDto>();
            CreateMap<SizeDto, Size>();
            CreateMap<Size, SizeCreateDto>();
            CreateMap<SizeCreateDto, SizeDto>();
            CreateMap<SizeCreateDto, Size>();
            CreateMap<SizeDto, SizeCreateDto>();
            CreateMap<SizeUpdateDto, Size>();
            CreateMap<SizeUpdateDto, SizeDto>();
            CreateMap<SizeDto, SizeUpdateDto>();
            CreateMap<Size, SizeUpdateDto>();
            CreateMap<BasePage<Size>, BasePage<SizeDto>>();
        }
    }
}
