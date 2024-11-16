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
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorDto>();
            CreateMap<ColorDto, Color>();
            CreateMap<Color, ColorCreateDto>();
            CreateMap<ColorCreateDto, ColorDto>();
            CreateMap<ColorCreateDto, Color>();
            CreateMap<ColorDto, ColorCreateDto>();
            CreateMap<ColorUpdateDto, Color>();
            CreateMap<ColorUpdateDto, ColorDto>();
            CreateMap<ColorDto, ColorUpdateDto>();
            CreateMap<Color, ColorUpdateDto>();
            CreateMap<BasePage<Color>, BasePage<ColorDto>>();
        }
    }
}
