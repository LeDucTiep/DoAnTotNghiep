using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Model;

namespace ldtiep.be.DL.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<string> CheckPassword(string Password, string EmployeeCode);
        Task<string> ChangePassword(string sessionID, string newPass);
        Task<Employee> GetUserInfor(string sessionID);
    }
}
