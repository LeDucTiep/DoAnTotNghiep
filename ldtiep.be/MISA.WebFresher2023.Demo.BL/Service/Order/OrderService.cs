using AutoMapper;
using ldtiep.be.BL.Dto;
using ldtiep.be.DL;
using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Repository;

namespace ldtiep.be.BL.Service
{
    public class OrderService : BaseService<Order, OrderDto, OrderCreateDto, OrderUpdateDto>, IOrderService
    {
        public OrderService(
            IOrderRepository sizeRepository,
           
            IMSDatabase msDatabase,
            IMapper mapper) : base(msDatabase, sizeRepository, mapper)
        {
           
        }
    }
}
