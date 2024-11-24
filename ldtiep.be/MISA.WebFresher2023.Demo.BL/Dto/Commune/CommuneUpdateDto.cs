using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.BL.Dto
{
    public class CommuneUpdateDto
    {
        public Guid CommuneID { get; set; }
        public string Name { get; set; }
        public Guid DistrictID { get; set; }
    }
}
