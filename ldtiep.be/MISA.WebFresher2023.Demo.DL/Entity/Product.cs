using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.DL.Entity
{
    public class Product : BaseEntity
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ColorIDs { get; set; }
        public string ColorCodes { get; set; }
        public string ColorNames { get; set; }
        public double Price { get; set; }
        public double OriginalPrice { get; set; }
        public double Discount { get; set; }
        public string SizeIDs { get; set; }
        public string SizeNames { get; set; }
        public string CategoryIDs { get; set; }
        public string CategoryNames { get; set; }
        public string PictureIDS { get; set; }
    }
}
