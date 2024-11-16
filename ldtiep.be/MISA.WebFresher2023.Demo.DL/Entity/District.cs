using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.DL.Entity
{
    public class District : BaseEntity
    {
        public Guid DistrictID { get; set; }
        public string Name { get; set; }
        public Guid CityID { get; set; }
    }
}
