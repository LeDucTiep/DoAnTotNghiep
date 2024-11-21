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
    public class PictureProfile : Profile
    {
        public PictureProfile()
        {
            CreateMap<Picture, PictureDto>();
            CreateMap<PictureDto, Picture>();
            CreateMap<Picture, PictureCreateDto>();
            CreateMap<PictureCreateDto, PictureDto>();
            CreateMap<PictureCreateDto, Picture>();
            CreateMap<PictureDto, PictureCreateDto>();
            CreateMap<PictureUpdateDto, Picture>();
            CreateMap<PictureUpdateDto, PictureDto>();
            CreateMap<PictureDto, PictureUpdateDto>();
            CreateMap<Picture, PictureUpdateDto>();
            CreateMap<BasePage<Picture>, BasePage<PictureDto>>();
        }
    }
}
