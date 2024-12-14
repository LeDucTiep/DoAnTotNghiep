using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.BL.Dto
{
    public class MessageUpdateDto
    {
        public Guid MessageID { get; set; }
        public Guid UserID { get; set; }
        public Guid? EmployeeID { get; set; }
        public string MessageContent { get; set; }
    }
}
