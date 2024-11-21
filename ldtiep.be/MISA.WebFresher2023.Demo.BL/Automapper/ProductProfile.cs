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
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductCreateDto>();
            CreateMap<ProductCreateDto, ProductDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductDto, ProductCreateDto>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<ProductUpdateDto, ProductDto>();
            CreateMap<ProductDto, ProductUpdateDto>();
            CreateMap<Product, ProductUpdateDto>();
            CreateMap<BasePage<Product>, BasePage<ProductDto>>();
        }
    }
}
