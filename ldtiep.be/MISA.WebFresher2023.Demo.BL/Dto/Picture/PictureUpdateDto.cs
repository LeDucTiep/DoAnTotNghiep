using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.BL.Dto
{
    public class PictureUpdateDto
    {
        public Guid PictureID { get; set; }
        public string PictureName { get; set; }
        public string PictureType { get; set; }
        public byte[]? PictureData { get; set; }
    }
}
