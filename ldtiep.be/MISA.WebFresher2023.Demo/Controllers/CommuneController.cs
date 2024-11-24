using Microsoft.AspNetCore.Mvc;
using ldtiep.be.BL.Dto;
using ldtiep.be.BL.Service;
using ldtiep.be.Controllers;
using ldtiep.be.DL.Entity;

namespace ldtiep.be.api.Controllers
{
    [Route("api/v1/[controller]s")]
    public class CommuneController : BaseController<Commune, CommuneDto, CommuneCreateDto, CommuneUpdateDto>
    {
        public ICommuneService _cityService;
        public CommuneController(ICommuneService cityService
            ) : base(cityService)
        {
            _cityService = cityService;
        }
    }
}
