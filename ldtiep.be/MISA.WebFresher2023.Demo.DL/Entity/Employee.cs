using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.DL.Entity
{
    public class Employee : BaseEntity
    {
        public Guid EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string Rules { get; set; }
        public string Password { get; set; }
        public Guid? SessionID { get; set; }
        public int TypeAccount { get; set; }
    }
}
