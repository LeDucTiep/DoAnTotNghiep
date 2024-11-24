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
    public class CommuneProfile : Profile
    {
        public CommuneProfile()
        {
            CreateMap<Commune, CommuneDto>();
            CreateMap<CommuneDto, Commune>();
            CreateMap<Commune, CommuneCreateDto>();
            CreateMap<CommuneCreateDto, CommuneDto>();
            CreateMap<CommuneCreateDto, Commune>();
            CreateMap<CommuneDto, CommuneCreateDto>();
            CreateMap<CommuneUpdateDto, Commune>();
            CreateMap<CommuneUpdateDto, CommuneDto>();
            CreateMap<CommuneDto, CommuneUpdateDto>();
            CreateMap<Commune, CommuneUpdateDto>();
            CreateMap<BasePage<Commune>, BasePage<CommuneDto>>();
        }
    }
}
