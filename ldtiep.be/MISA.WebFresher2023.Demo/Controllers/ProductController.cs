using Microsoft.AspNetCore.Mvc;
using ldtiep.be.BL.Dto;
using ldtiep.be.BL.Service;
using ldtiep.be.Controllers;
using ldtiep.be.DL.Entity;

namespace ldtiep.be.api.Controllers
{
    [Route("api/v1/[controller]s")]
    public class ProductController : BaseController<Product, ProductDto, ProductCreateDto, ProductUpdateDto>
    {
        public IProductService _productService;
        public ProductController(IProductService productService
            ) : base(productService)
        {
            _productService = productService;
        }
    }
}
