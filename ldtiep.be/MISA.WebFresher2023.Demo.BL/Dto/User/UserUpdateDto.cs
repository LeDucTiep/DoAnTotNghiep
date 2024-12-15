using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.BL.Dto
{
    public class UserUpdateDto
    {
        public Guid UserID { get; set; }
        public Guid? PictureID { get; set; }
        public string UserName { get; set; }
    }
}
