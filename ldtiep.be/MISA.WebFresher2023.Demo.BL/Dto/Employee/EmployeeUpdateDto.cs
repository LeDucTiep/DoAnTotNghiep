using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.BL.Dto
{
    public class EmployeeUpdateDto
    {
        public Guid EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string Rules { get; set; }
    }
}
