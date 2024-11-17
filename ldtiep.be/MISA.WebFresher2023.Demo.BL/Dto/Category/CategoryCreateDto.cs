using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.BL.Dto
{
    public class CategoryCreateDto
    {
        public string CategoryName { get; set; }
        public int SortOrder { get; set; }
        public int CategoryType { get; set; }
        public Guid? ParentID { get; set; }
        public List<Dictionary<string,object>>? Children { get; set; }

    }
}
