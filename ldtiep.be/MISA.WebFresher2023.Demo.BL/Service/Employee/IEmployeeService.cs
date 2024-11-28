using ldtiep.be.BL.Dto;

namespace ldtiep.be.BL.Service
{
    public interface IEmployeeService : IBaseService<EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>
    {
        Task<string> CheckPassword(string Password, string EmployeeCode);
        Task<string> ChangePassword(string sessionID, string newPass);
        Task<EmployeeDto> GetUserInfor(string sessionID);
    }
}
