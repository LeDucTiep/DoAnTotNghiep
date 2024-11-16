using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.DL.Entity
{
    public class City : BaseEntity
    {
        public Guid CityID { get; set; }
        public string Name { get; set; }
    }
}
