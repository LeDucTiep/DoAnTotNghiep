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
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryCreateDto>();
            CreateMap<CategoryCreateDto, CategoryDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryDto, CategoryCreateDto>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryUpdateDto, CategoryDto>();
            CreateMap<CategoryDto, CategoryUpdateDto>();
            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<BasePage<Category>, BasePage<CategoryDto>>();
        }
    }
}
