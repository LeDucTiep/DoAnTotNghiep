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

        [HttpGet("gen-new-key")]
        public async Task<IActionResult> GenNewKeyAsync(Guid id)
        {

            Random random = new();


            bool isExists = false;
            string newCode = "";

            do
            {
                string str = new(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 3).Select(s => s[random.Next(s.Length)]).ToArray());
                string num = new(Enumerable.Repeat("0123456789", 4).Select(s => s[random.Next(s.Length)]).ToArray());

                newCode = $"{str}{num}";

                isExists = await _baseService.CheckExistedAsync(new Dictionary<string, string>() {
                    { "ProductCode", newCode }
                });
            }
            while (isExists);

            return StatusCode(200, newCode);
        }
    }


}
