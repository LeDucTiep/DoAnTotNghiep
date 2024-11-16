using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.DL.Entity
{
    public class Color : BaseEntity
    {
        public Guid ColorID { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
    }
}
