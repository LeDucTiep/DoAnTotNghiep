using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.DL.Entity
{
    public class Size : BaseEntity
    {
        public Guid SizeID { get; set; }
        public string SizeName { get; set; }
    }
}
