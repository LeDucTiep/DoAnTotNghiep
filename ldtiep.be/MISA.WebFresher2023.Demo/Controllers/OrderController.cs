using Microsoft.AspNetCore.Mvc;
using ldtiep.be.BL.Dto;
using ldtiep.be.BL.Service;
using ldtiep.be.Controllers;
using ldtiep.be.DL.Entity;

namespace ldtiep.be.api.Controllers
{
    [Route("api/v1/[controller]s")]
    public class OrderController : BaseController<Order, OrderDto, OrderCreateDto, OrderUpdateDto>
    {
        public IOrderService _sizeService;
        public OrderController(IOrderService sizeService
            ) : base(sizeService)
        {
            _sizeService = sizeService;
        }
    }
}
