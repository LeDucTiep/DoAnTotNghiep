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
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderCreateDto>();
            CreateMap<OrderCreateDto, OrderDto>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderDto, OrderCreateDto>();
            CreateMap<OrderUpdateDto, Order>();
            CreateMap<OrderUpdateDto, OrderDto>();
            CreateMap<OrderDto, OrderUpdateDto>();
            CreateMap<Order, OrderUpdateDto>();
            CreateMap<BasePage<Order>, BasePage<OrderDto>>();
        }
    }
}
