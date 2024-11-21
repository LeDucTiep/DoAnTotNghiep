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
        /// Tìm kiếm theo toán tử =
        /// </summary>
        /// Author: LeDucTiep (09/06/2023)
        public Dictionary<string, object>? SearchEquals { get; set; }
        /// <summary>
        /// Tìm kiếm theo toán tử in
        /// </summary>
        /// Author: LeDucTiep (09/06/2023)
        public Dictionary<string, object>? SearchIn { get; set; }
        public Dictionary<string, object>? SearchSmaller { get; set; }
        public Dictionary<string, object>? SearchBigger { get; set; }
        /// <summary>
        /// Tham số sắp xếp
        /// </summary>
        public Dictionary<string, object>? Sorter { get; set; }
    }
}
