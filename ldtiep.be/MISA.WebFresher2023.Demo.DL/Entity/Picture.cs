using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.DL.Entity
{
    public class Picture : BaseEntity
    {
        public Guid PictureID { get; set; }
        public string PictureType { get; set; }
        public byte[]? PictureData { get; set; }
    }
}
