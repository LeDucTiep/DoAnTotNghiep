using Microsoft.AspNetCore.Mvc;
using ldtiep.be.BL.Dto;
using ldtiep.be.BL.Service;
using ldtiep.be.Controllers;
using ldtiep.be.DL.Entity;

namespace ldtiep.be.api.Controllers
{
    [Route("api/v1/[controller]s")]
    public class SizeController : BaseController<Size, SizeDto, SizeCreateDto, SizeUpdateDto>
    {
        public ISizeService _sizeService;
        public SizeController(ISizeService sizeService
            ) : base(sizeService)
        {
            _sizeService = sizeService;
        }
    }
}
