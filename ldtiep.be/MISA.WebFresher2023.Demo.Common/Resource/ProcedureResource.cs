﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldtiep.be.Common.Resource
{
    /// <summary>
    /// Class tên procedure
    /// </summary>
    /// Author: LeDucTiep (23/05/2023)
    public class ProcedureResource
    {
        #region Field
        /// <summary>
        /// Procedure kiểm cha employeeCode đã tồn tại chưa 
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        public static readonly string EmployeeCheckDuplicatedCode = "Proc_Employee_CheckDuplicatedCode";
        public static readonly string ReceiptCheckDuplicatedCode = "Proc_Receipt_CheckDuplicatedCode";
        public static readonly string ProductCheckDuplicatedCode = "Proc_Product_CheckDuplicatedCode";
        public static readonly string CustomerCheckDuplicatedCode = "Proc_Customer_CheckDuplicatedCode";

        /// <summary>
        /// Procedure kiểm cha employeeCode muốn sửa đã tồn tại chưa, ngoại trừ mã trước khi sửa
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        public static readonly string EmployeeCheckDuplicatedCodeExceptItsCode = "Proc_Employee_CheckDuplicatedCodeExceptItsCode";
        public static readonly string ReceiptCheckDuplicatedCodeExceptItsCode = "Proc_Receipt_CheckDuplicatedCodeExceptItsCode";
        public static readonly string ProductCheckDuplicatedCodeExceptItsCode = "Proc_Product_CheckDuplicatedCodeExceptItsCode";
        public static readonly string CustomerCheckDuplicatedCodeExceptItsCode = "Proc_Customer_CheckDuplicatedCodeExceptItsCode";

        /// <summary>
        /// Procedure kiểm cha employeeCode muốn sửa đã tồn tại chưa, ngoại trừ mã trước khi sửa
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        public static readonly string EmployeeCheckDuplicatedCodeExceptItsId = "Proc_Employee_CheckDuplicatedCodeExceptItsId";
        public static readonly string ReceiptCheckDuplicatedCodeExceptItsId = "Proc_Receipt_CheckDuplicatedCodeExceptItsId";
        public static readonly string ProductCheckDuplicatedCodeExceptItsId = "Proc_Product_CheckDuplicatedCodeExceptItsId";
        public static readonly string CustomerCheckDuplicatedCodeExceptItsId = "Proc_Customer_CheckDuplicatedCodeExceptItsId";

        /// <summary>
        /// Procedure phân trang theo họ tên và mã nhân viên
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        public static readonly string EmployeeExport = "Proc_Employee_Export";

        public static readonly string CustomerAndGroupGetCustomerGroupIdByCustomerId = "Proc_CustomerAndGroup_GetCustomerGroupIdByCustomerId";
        public static readonly string BankProductGetByCustomerId = "Proc_BankProduct_GetByCustomerId";
        public static readonly string OtherLocationGetByCustomerId = "Proc_OtherLocation_GetByCustomerId";
        public static readonly string SpecificAddressGetByOtherLocationId = "Proc_SpecificAddress_GetByOtherLocationId";

        public static readonly string CustomerAndGroupDeleteNotIn = "Proc_CustomerAndGroup_DeleteNotIn";
        public static readonly string BankProductDeleteNotIn = "Proc_BankProduct_DeleteNotIn";
        public static readonly string SpecificAddressDeleteNotIn = "Proc_SpecificAddress_DeleteNotIn";


        public static readonly string ProductPagingByRank = "Proc_Product_PagingByRank";
        public static readonly string ProductCheckIsParent = "Proc_Product_CheckIsParent";
        public static readonly string ProductCheckIsGrandpa = "Proc_Product_CheckIsGrandpa";
        public static readonly string ProductCheckIsChangedProductCode = "Proc_Product_CheckIsChangedProductCode";
        public static readonly string ProductCheckIsChangedParentId = "Proc_Product_CheckIsChangedParentId";
        public static readonly string ProductUpdateMisaCode = "Proc_Product_UpdateMisaCode";
        public static readonly string ProductCheckUpdateCodeBeDublicated = "Proc_Product_CheckUpdateCodeBeDublicated";
        public static readonly string ProductRecalculateMisaCode = "Proc_Product_RecalculateMisaCode";

        public static readonly string BookKeepingGetByReceiptId = "Proc_BookKeeping_GetByReceiptId";

        public static readonly string BookKeepingAddMany = "Proc_BookKeeping_AddMany";
        public static readonly string BookKeepingDeleteNotIn = "Proc_BookKeeping_DeleteNotIn";

        public static readonly string ReceiptSetRecorded = "Proc_Receipt_SetRecorded";

        #endregion

        #region Method
        public static string Export(string tableName)
        {
            return $"Proc_{tableName}_Export";
        }

        /// <summary>
        /// Procedure Kiểm tra bản ghi có tồn tại không bằng id bản ghi
        /// </summary>
        /// <param name="tableName">Tên của bảng</param>
        /// <returns>Procedure</returns>
        /// Author: LeDucTiep (23/05/2023)
        public static string CheckExistedById(string tableName)
        {
            return $"Proc_{tableName}_CheckExistedById";
        }
        public static string GetPaging(string tableName)
        {
            return $"Proc_{tableName}_Paging";
        }

        /// <summary>
        /// Procedure lấy tất cả bản ghi
        /// </summary>
        /// <param name="tableName">Tên của bảng</param>
        /// <returns>Procedure</returns>
        /// Author: LeDucTiep (23/05/2023)
        public static string GetAll(string tableName)
        {
            return $"Proc_{tableName}_GetAll";
        }

        /// <summary>
        /// Procedure lấy một bản ghi
        /// </summary>
        /// <param name="tableName">Tên của bảng</param>
        /// <returns>Procedure</returns>
        /// Author: LeDucTiep (23/05/2023)
        public static string Get(string tableName)
        {
            return $"Proc_{tableName}_GetById";
        }

        /// <summary>
        /// Procedure cập nhật bản ghi
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <returns>Procedure</returns>
        /// Author: LeDucTiep (23/05/2023)
        public static string Update(string tableName)
        {
            return $"Proc_{tableName}_Edit";
        }

        /// <summary>
        /// Procedure thêm một bản ghi
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <returns>Procedure</returns>
        /// Author: LeDucTiep (23/05/2023)
        public static string Add(string tableName)
        {
            return $"Proc_{tableName}_Add";
        }

        /// <summary>
        /// Procedure xóa một bản ghi
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <returns>Procedure</returns>
        /// Author: LeDucTiep (23/05/2023)
        public static string Delete(string tableName)
        {
            return $"Proc_{tableName}_Delete";
        }

        /// <summary>
        /// Procedure xóa nhiều bản ghi
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        /// <returns>Procedure</returns>
        /// Author: LeDucTiep (23/05/2023)
        public static string DeleteMany(string tableName)
        {
            return $"Proc_{tableName}_DeleteMany";
        }
        #endregion
    }
}
