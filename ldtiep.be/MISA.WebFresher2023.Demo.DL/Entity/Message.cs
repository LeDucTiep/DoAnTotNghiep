using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.DL.Entity
{
    public class Message : BaseEntity
    {
        public Guid MessageID { get; set; }
        public Guid UserID { get; set; }
        public Guid? EmployeeID { get; set; }
        public string MessageContent { get; set; }
    }
}
