using ldtiep.be.Common.Attribute;
using ldtiep.be.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.DL.Model
{
    public class BasePagingArgument
    {
        private int pageSize = 20;
        private int pageNumber = 1;

        /// <summary>
        /// Kích thước trang 
        /// </summary>
        /// Author: LeDucTiep (09/06/2023)
        public int PageSize { get => pageSize; set => pageSize = value; }

        /// <summary>
        /// Số trang
        /// </summary>
        /// Author: LeDucTiep (09/06/2023)
        public int PageNumber { get => pageNumber; set => pageNumber = value; }

        /// <summary>
        /// Từ khóa cần tìm kiếm
        /// </summary>
        /// Author: LeDucTiep (09/06/2023)
        public Dictionary<string, object>? SearchTerm { get; set; }
    }
}
