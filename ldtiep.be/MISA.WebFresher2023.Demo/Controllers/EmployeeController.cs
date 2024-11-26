using Microsoft.AspNetCore.Mvc;
using ldtiep.be.BL.Dto;
using ldtiep.be.BL.Service;
using ldtiep.be.Controllers;
using ldtiep.be.DL.Entity;

namespace ldtiep.be.api.Controllers
{
    [Route("api/v1/[controller]s")]
    public class EmployeeController : BaseController<Employee, EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>
    {
        public IEmployeeService _sizeService;
        public EmployeeController(IEmployeeService sizeService
            ) : base(sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet("gen-code")]
        public virtual async Task<IActionResult> GenCode(Guid id)
        {
            string newCode;
            bool isExists;
            int c = 0;
            do
            {
                c++;
                newCode = $"NV0{c}";
                Dictionary<string, string> param = new()
                {
                       { "EmployeeCode" , newCode }
                };

                isExists = await _baseService.CheckExistedAsync(param);
            }
            while (isExists);

            return Ok(newCode);
        }

    }
}
