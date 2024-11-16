using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.BL.Dto
{
    public class ColorUpdateDto
    {
        public Guid ColorID { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
    }
}
