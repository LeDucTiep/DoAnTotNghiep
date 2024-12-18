﻿
namespace ldtiep.be.BL.Dto
{
    public class OrderDto
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
        public string PayType { get; set; }
        public double TotalPrice { get; set; }
        public int OrderStatus { get; set; }
    }
}
