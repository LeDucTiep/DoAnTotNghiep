using Microsoft.AspNetCore.Mvc;
using ldtiep.be.BL.Dto;
using ldtiep.be.BL.Service;
using ldtiep.be.Controllers;
using ldtiep.be.DL.Entity;
using ldtiep.be.Common;
using static System.Net.Mime.MediaTypeNames;

namespace ldtiep.be.api.Controllers
{
    [Route("api/v1/[controller]s")]
    public class PictureController : BaseController<Picture, PictureDto, PictureCreateDto, PictureUpdateDto>
    {
        public IPictureService _productService;
        public PictureController(IPictureService productService
            ) : base(productService)
        {
            _productService = productService;
        }
        [HttpPost("image")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var imageData = memoryStream.ToArray();

            var image = new PictureCreateDto
            {
                PictureType = file.ContentType,
                PictureData = imageData
            };

            PictureDto pictureDto = await _baseService.PostAsync(image);

            return StatusCode(201, pictureDto);
        }
        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(Guid id)
        {
            PictureDto? entityDto = await _baseService.GetAsync(id);

            if (entityDto == null || entityDto.PictureData == null)
                return NoContent();

            return File(entityDto.PictureData, entityDto.PictureType);
        }
    }
}
