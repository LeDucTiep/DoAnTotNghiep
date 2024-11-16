using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.DL.Entity
{
    public class Payment : BaseEntity
    {
        public Guid PaymentID { get; set; }
        public string PaymentName { get; set; }
    }
}
