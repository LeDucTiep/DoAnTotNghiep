using Microsoft.AspNetCore.Mvc;
using ldtiep.be.BL.Dto;
using ldtiep.be.BL.Service;
using ldtiep.be.Controllers;
using ldtiep.be.DL.Entity;

namespace ldtiep.be.api.Controllers
{
    [Route("api/v1/[controller]s")]
    public class CityController : BaseController<City, CityDto, CityCreateDto, CityUpdateDto>
    {
        public ICityService _cityService;
        public CityController(ICityService cityService
            ) : base(cityService)
        {
            _cityService = cityService;
        }
    }
}
