using Microsoft.AspNetCore.Mvc;
using ldtiep.be.BL.Dto;
using ldtiep.be.BL.Service;
using ldtiep.be.Controllers;
using ldtiep.be.DL.Entity;

namespace ldtiep.be.api.Controllers
{
    [Route("api/v1/[controller]s")]
    public class CategoryController : BaseController<Category, CategoryDto, CategoryCreateDto, CategoryUpdateDto>
    {
        public ICategoryService _productService;
        public CategoryController(ICategoryService productService
            ) : base(productService)
        {
            _productService = productService;
        }
    }
}
