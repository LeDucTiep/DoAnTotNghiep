using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ldtiep.be.BL.Dto
{
    public class PictureCreateDto
    {
        public string PictureType { get; set; }
        public byte[]? PictureData { get; set; }
        public IFormFile file { get; set; }
    }
}
