using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.DL.Entity
{
    public class Category : BaseEntity
    {
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public Guid? ParentID { get; set; }
        public int SortOrder { get; set; }
        public int CategoryType { get; set; }
    }
}
