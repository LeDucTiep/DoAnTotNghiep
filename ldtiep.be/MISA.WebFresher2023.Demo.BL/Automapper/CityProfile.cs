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
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<CityDto, City>();
            CreateMap<City, CityCreateDto>();
            CreateMap<CityCreateDto, CityDto>();
            CreateMap<CityCreateDto, City>();
            CreateMap<CityDto, CityCreateDto>();
            CreateMap<CityUpdateDto, City>();
            CreateMap<CityUpdateDto, CityDto>();
            CreateMap<CityDto, CityUpdateDto>();
            CreateMap<City, CityUpdateDto>();
            CreateMap<BasePage<City>, BasePage<CityDto>>();
        }
    }
}
