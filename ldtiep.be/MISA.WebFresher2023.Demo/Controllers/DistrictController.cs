using Microsoft.AspNetCore.Mvc;
using ldtiep.be.BL.Dto;
using ldtiep.be.BL.Service;
using ldtiep.be.Controllers;
using ldtiep.be.DL.Entity;

namespace ldtiep.be.api.Controllers
{
    [Route("api/v1/[controller]s")]
    public class DistrictController : BaseController<District, DistrictDto, DistrictCreateDto, DistrictUpdateDto>
    {
        public IDistrictService _cityService;
        public DistrictController(IDistrictService cityService
            ) : base(cityService)
        {
            _cityService = cityService;
        }
    }
}
