using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.BL.Dto
{
    public class PictureCreateDto
    {
        public string PictureName { get; set; }
        public byte[]? PictureData { get; set; }
    }
}
