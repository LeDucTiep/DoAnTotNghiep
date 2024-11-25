using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.DL.Entity
{
    public class Order : BaseEntity
    {
        public Guid OrderID { get; set; }
        public string Products { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeExtraAddress { get; set; }
        public string EmployeeNote { get; set; }
        public double TransCost { get; set; }
        public double TransCostDiscount { get; set; }
        public double TotalPay { get; set; }
        public double TotalPrice { get; set; }
        public int OrderStatus { get; set; }
    }
}
