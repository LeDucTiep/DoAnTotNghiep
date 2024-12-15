using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.DL.Entity
{
    public class User : BaseEntity
    {
        public Guid UserID { get; set; }
        public Guid? PictureID { get; set; }
        public string UserName { get; set; }
    }
}
