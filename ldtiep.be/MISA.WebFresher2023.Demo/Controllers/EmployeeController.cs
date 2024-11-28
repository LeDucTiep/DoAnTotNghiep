using Microsoft.AspNetCore.Mvc;
using ldtiep.be.BL.Dto;
using ldtiep.be.BL.Service;
using ldtiep.be.Controllers;
using ldtiep.be.DL.Entity;

namespace ldtiep.be.api.Controllers
{
    public class PW
    {
        public string Password { get; set; }
        public string EmployeeCode { get; set; }
    }
    [Route("api/v1/[controller]s")]
    public class EmployeeController : BaseController<Employee, EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>
    {
        public IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService
            ) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("user-infor/{sessionID}")]
        public async Task<IActionResult> GetUserInfor(string sessionID)
        {
            EmployeeDto e = await _employeeService.GetUserInfor(sessionID);

            return Ok(e);
        }

        [HttpPost("check-password")]
        public async Task<IActionResult> CheckPassword([FromBody] PW p)
        {
            string sessionID = await _employeeService.CheckPassword(p.Password, p.EmployeeCode);

            return Ok(sessionID);
        }
        [HttpGet("change-password/{sessionID}/{newPass}")]
        public async Task<IActionResult> ChangePassword(string sessionID, string newPass)
        {
            await _employeeService.ChangePassword(sessionID, newPass);

            return Ok();
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
