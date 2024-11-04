using ldtiep.be.Common.Constant;
using ldtiep.be.Common.Resource;
using System.Net;

namespace ldtiep.be.Common
{
    /// <summary>
    /// Class Exception
    /// </summary>
    /// Author: LeDucTiep (23/05/2023)
    public class BadRequestException : BaseException
    {
        #region Field 
        /// <summary>
        /// Http code
        /// </summary>
        /// Author: LeDucTiep (09/06/2023)
        public readonly int StatusCode = (int)HttpStatusCode.BadRequest;
        #endregion

        #region Contructor
        public BadRequestException() : base()
        {
        }

        public BadRequestException(List<int> errorCode) : base(errorCode)
        {
            List<string> userMessage = base.UserMessage;
            List<string> devMessage = base.DevMessage;

            foreach (int code in errorCode)
            {
                switch (code)
                {
                    // Receipt
                    case (int)ReceiptErrorCode.CodeTooLong:
                        userMessage.Add(ReceiptUserMessage.CodeTooLong);
                        devMessage.Add(ReceiptDevMessage.CodeTooLong);
                        break;
                    case (int)ReceiptErrorCode.DeleteBooked:
                        userMessage.Add(ReceiptUserMessage.DeleteBooked);
                        devMessage.Add(ReceiptDevMessage.DeleteBooked);
                        break;



                    // Product

                    case (int)ProductErrorCode.CodeTooLong:
                        userMessage.Add(ProductUserMessage.CodeTooLong);
                        devMessage.Add(ProductDevMessage.CodeTooLong);
                        break;
                    
                    case (int)ProductErrorCode.CantDeleteProductInReceipt:
                        userMessage.Add(ProductUserMessage.CantDeleteProductInReceipt);
                        devMessage.Add(ProductDevMessage.CantDeleteProductInReceipt);
                        break;
                    case (int)ProductErrorCode.CodeIsRequired:
                        userMessage.Add(ProductUserMessage.CodeIsRequired);
                        devMessage.Add(ProductDevMessage.CodeIsRequired);
                        break;
                    case (int)ProductErrorCode.NameIsRequired:
                        userMessage.Add(ProductUserMessage.NameIsRequired);
                        devMessage.Add(ProductDevMessage.NameIsRequired);
                        break;
                    case (int)ProductErrorCode.ProductPropertyIsRequired:
                        userMessage.Add(ProductUserMessage.ProductPropertyIsRequired);
                        devMessage.Add(ProductDevMessage.ProductPropertyIsRequired);
                        break;
                    case (int)ProductErrorCode.NameViTooLong:
                        userMessage.Add(ProductUserMessage.NameViTooLong);
                        devMessage.Add(ProductDevMessage.NameViTooLong);
                        break;
                    case (int)ProductErrorCode.NameEnTooLong:
                        userMessage.Add(ProductUserMessage.NameEnTooLong);
                        devMessage.Add(ProductDevMessage.NameEnTooLong);
                        break;

                    case (int)ProductErrorCode.NoteTooLong:
                        userMessage.Add(ProductUserMessage.NoteTooLong);
                        devMessage.Add(ProductDevMessage.NoteTooLong);
                        break;

                    case (int)ProductErrorCode.CantDeleteParent:
                        userMessage.Add(ProductUserMessage.CantDeleteParent);
                        devMessage.Add(ProductDevMessage.CantDeleteParent);
                        break;
                    case (int)ProductErrorCode.DuplicatedCode:
                        userMessage.Add(ProductUserMessage.DuplicatedCode);
                        devMessage.Add(ProductDevMessage.DuplicatedCode);
                        break;


                    // customer
                    case (int)CustomerErrorCode.TaxCodeTooLong:
                        userMessage.Add(CustomerUserMessage.TaxCodeTooLong);
                        devMessage.Add(CustomerDevMessage.TaxCodeTooLong);
                        break;case (int)CustomerErrorCode.CantDeleteCustomerInReceipt:
                        userMessage.Add(CustomerUserMessage.CantDeleteCustomerInReceipt);
                        devMessage.Add(CustomerDevMessage.CantDeleteCustomerInReceipt);
                        break;
                    case (int)CustomerErrorCode.CodeIsRequired:
                        userMessage.Add(CustomerUserMessage.CodeIsRequired);
                        devMessage.Add(CustomerDevMessage.CodeIsRequired);
                        break;
                    case (int)CustomerErrorCode.FullNameIsRequired:
                        userMessage.Add(CustomerUserMessage.FullNameIsRequired);
                        devMessage.Add(CustomerDevMessage.FullNameIsRequired);
                        break;
                    case (int)CustomerErrorCode.FullNameTooLong:
                        userMessage.Add(CustomerUserMessage.FullNameTooLong);
                        devMessage.Add(CustomerDevMessage.FullNameTooLong);
                        break;
                    case (int)CustomerErrorCode.AddressTooLong:
                        userMessage.Add(CustomerUserMessage.AddressTooLong);
                        devMessage.Add(CustomerDevMessage.AddressTooLong);
                        break;
                    case (int)CustomerErrorCode.PhoneNumberTooLong:
                        userMessage.Add(CustomerUserMessage.PhoneNumberTooLong);
                        devMessage.Add(CustomerDevMessage.PhoneNumberTooLong);
                        break;
                    case (int)CustomerErrorCode.WebsiteTooLong:
                        userMessage.Add(CustomerUserMessage.WebsiteTooLong);
                        devMessage.Add(CustomerDevMessage.WebsiteTooLong);
                        break;
                    case (int)CustomerErrorCode.NoteTooLong:
                        userMessage.Add(CustomerUserMessage.NoteTooLong);
                        devMessage.Add(CustomerDevMessage.NoteTooLong);
                        break;
                    case (int)CustomerErrorCode.IdentityNumberTooLong:
                        userMessage.Add(CustomerUserMessage.IdentityNumberTooLong);
                        devMessage.Add(CustomerDevMessage.IdentityNumberTooLong);
                        break;
                    case (int)CustomerErrorCode.IdentityPlaceTooLong:
                        userMessage.Add(CustomerUserMessage.IdentityPlaceTooLong);
                        devMessage.Add(CustomerDevMessage.IdentityPlaceTooLong);
                        break;
                    case (int)CustomerErrorCode.CustomerCodeTooLong:
                        userMessage.Add(CustomerUserMessage.CustomerCodeTooLong);
                        devMessage.Add(CustomerDevMessage.CustomerCodeTooLong);
                        break;


                    case (int)EmployeeErrorCode.GuidInvalid:
                        userMessage.Add(EmployeeUserMessage.GuidInvalid);
                        devMessage.Add(EmployeeDevMessage.GuidInvalid);
                        break;

                    case (int)RequestErrorCode.GuidInvalid:
                        userMessage.Add(RequestUserMessage.GuidInvalid);
                        devMessage.Add(RequestDevMessage.GuidInvalid);
                        break;

                    // Nhân viên 
                    case (int)EmployeeErrorCode.CodeDuplicated:
                        userMessage.Add(EmployeeUserMessage.CodeDuplicated);
                        devMessage.Add(EmployeeDevMessage.CodeDuplicated);
                        break;
                    case (int)EmployeeErrorCode.CantDeleteEmployeeInCustomer:
                        userMessage.Add(EmployeeUserMessage.CantDeleteEmployeeInCustomer);
                        devMessage.Add(EmployeeDevMessage.CantDeleteEmployeeInCustomer);
                        break;
                    case (int)EmployeeErrorCode.CantDeleteEmployeeInReceipt:
                        userMessage.Add(EmployeeUserMessage.CantDeleteEmployeeInReceipt);
                        devMessage.Add(EmployeeDevMessage.CantDeleteEmployeeInReceipt);
                        break;
                    
                    case (int)EmployeeErrorCode.IdNotFound:
                        userMessage.Add(EmployeeUserMessage.IdNotFound);
                        devMessage.Add(EmployeeDevMessage.IdNotFound);
                        break;

                    case (int)EmployeeErrorCode.CodeIsRequired:
                        userMessage.Add(EmployeeUserMessage.CodeIsRequired);
                        devMessage.Add(EmployeeDevMessage.CodeIsRequired);
                        break;

                    case (int)EmployeeErrorCode.FullNameIsRequired:
                        userMessage.Add(EmployeeUserMessage.FullNameIsRequired);
                        devMessage.Add(EmployeeDevMessage.FullNameIsRequired);
                        break;

                    case (int)EmployeeErrorCode.EmployeeCodeTooLong:
                        userMessage.Add(EmployeeUserMessage.EmployeeCodeTooLong);
                        devMessage.Add(EmployeeDevMessage.EmployeeCodeTooLong);
                        break;

                    case (int)EmployeeErrorCode.FullNameTooLong:
                        userMessage.Add(EmployeeUserMessage.FullNameTooLong);
                        devMessage.Add(EmployeeDevMessage.FullNameTooLong);
                        break;

                    case (int)EmployeeErrorCode.EmailTooLong:
                        userMessage.Add(EmployeeUserMessage.EmailTooLong);
                        devMessage.Add(EmployeeDevMessage.EmailTooLong);

                        break;
                    case (int)EmployeeErrorCode.AddressTooLong:
                        userMessage.Add(EmployeeUserMessage.AddressTooLong);
                        devMessage.Add(EmployeeDevMessage.AddressTooLong);
                        break;

                    case (int)EmployeeErrorCode.PhoneNumberTooLong:
                        userMessage.Add(EmployeeUserMessage.PhoneNumberTooLong);
                        devMessage.Add(EmployeeDevMessage.PhoneNumberTooLong);
                        break;

                    case (int)EmployeeErrorCode.IdentityNumberTooLong:
                        userMessage.Add(EmployeeUserMessage.IdentityNumberTooLong);
                        devMessage.Add(EmployeeDevMessage.IdentityNumberTooLong);
                        break;

                    case (int)EmployeeErrorCode.IdentityNumberInvalid:
                        userMessage.Add(EmployeeUserMessage.IdentityNumberInvalid);
                        devMessage.Add(EmployeeDevMessage.IdentityNumberInvalid);
                        break;

                    case (int)EmployeeErrorCode.IdentityPlaceTooLong:
                        userMessage.Add(EmployeeUserMessage.IdentityPlaceTooLong);
                        devMessage.Add(EmployeeDevMessage.IdentityPlaceTooLong);
                        break;

                    case (int)EmployeeErrorCode.BankProductNumberTooLong:
                        userMessage.Add(EmployeeUserMessage.BankProductNumberTooLong);
                        devMessage.Add(EmployeeDevMessage.BankProductNumberTooLong);
                        break;

                    case (int)EmployeeErrorCode.NameOfBankTooLong:
                        userMessage.Add(EmployeeUserMessage.NameOfBankTooLong);
                        devMessage.Add(EmployeeDevMessage.NameOfBankTooLong);
                        break;

                    case (int)EmployeeErrorCode.BankProductBranchTooLong:
                        userMessage.Add(EmployeeUserMessage.BankProductBranchTooLong);
                        devMessage.Add(EmployeeDevMessage.BankProductBranchTooLong);
                        break;

                    case (int)EmployeeErrorCode.DateOfBirthInvalidTime:
                        userMessage.Add(EmployeeUserMessage.DateOfBirthInvalidTime);
                        devMessage.Add(EmployeeDevMessage.DateOfBirthInvalidTime);
                        break;

                    case (int)EmployeeErrorCode.IdentityDateInvalidTime:
                        userMessage.Add(EmployeeUserMessage.IdentityDateInvalidTime);
                        devMessage.Add(EmployeeDevMessage.IdentityDateInvalidTime);
                        break;

                    case (int)EmployeeErrorCode.EmailInvalid:
                        userMessage.Add(EmployeeUserMessage.EmailInvalid);
                        devMessage.Add(EmployeeDevMessage.EmailInvalid);
                        break;

                    // Phòng ban 
                    case (int)DepartmentErrorCode.IdNotFound:
                        userMessage.Add(DepartmentUserMessage.IdNotFound);
                        devMessage.Add(DepartmentDevMessage.IdNotFound);
                        break;

                    // Chức vụ
                    case (int)PositionErrorCode.IdNotFound:
                        userMessage.Add(PositionUserMessage.IdNotFound);
                        devMessage.Add(PositionDevMessage.IdNotFound);
                        break;

                    // Phân trang
                    case (int)PagingErrorCode.InvalidPageSize:
                        userMessage.Add(PagingUserMessage.InvalidPageSize);
                        devMessage.Add(PagingDevMessage.InvalidPageSize);
                        break;

                    case (int)PagingErrorCode.InvalidPageNumber:
                        userMessage.Add(PagingUserMessage.InvalidPageNumber);
                        devMessage.Add(PagingDevMessage.InvalidPageNumber);
                        break;

                    case (int)PagingErrorCode.EmployeeSearchTermTooLong:
                        userMessage.Add(PagingUserMessage.EmployeeSearchTermTooLong);
                        devMessage.Add(PagingDevMessage.EmployeeSearchTermTooLong);
                        break;
                }
            }

            ErrorCode = errorCode;
            UserMessage = userMessage;
            DevMessage = devMessage;
        }
        #endregion
    }
}
