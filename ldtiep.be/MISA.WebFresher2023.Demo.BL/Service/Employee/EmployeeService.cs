using AutoMapper;
using ldtiep.be.BL.Dto;
using ldtiep.be.DL;
using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Repository;

namespace ldtiep.be.BL.Service
{
    public class EmployeeService : BaseService<Employee, EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>, IEmployeeService
    {
        IEmployeeRepository repo;
        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IMSDatabase msDatabase,
            IMapper mapper) : base(msDatabase, employeeRepository, mapper)
        {
            repo = employeeRepository;
        }
        public async Task<string> CheckPassword(string Password, string EmployeeCode)
        {
            string sessionID = await repo.CheckPassword(Password, EmployeeCode);

            return sessionID;
        }
        public async Task<string> ChangePassword(string sessionID, string newPass)
        {
            await repo.ChangePassword(sessionID, newPass);

            return "";
        }
        public async Task<EmployeeDto> GetUserInfor(string sessionID)
        {
            Employee em = await repo.GetUserInfor(sessionID);

            EmployeeDto res = _mapper.Map<EmployeeDto>(em);

            return res;
        }
    }
}
