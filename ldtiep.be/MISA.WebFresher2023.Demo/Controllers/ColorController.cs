using Microsoft.AspNetCore.Mvc;
using ldtiep.be.BL.Dto;
using ldtiep.be.BL.Service;
using ldtiep.be.Controllers;
using ldtiep.be.DL.Entity;

namespace ldtiep.be.api.Controllers
{
    [Route("api/v1/[controller]s")]
    public class ColorController : BaseController<Color, ColorDto, ColorCreateDto, ColorUpdateDto>
    {
        public IColorService _productService;
        public ColorController(IColorService productService
            ) : base(productService)
        {
            _productService = productService;
        }
    }
}
