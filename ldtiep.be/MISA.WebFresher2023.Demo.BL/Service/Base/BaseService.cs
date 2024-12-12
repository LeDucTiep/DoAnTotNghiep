using AutoMapper;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2010.Excel;
using ldtiep.be.Common;
using ldtiep.be.Common.Attribute;
using ldtiep.be.Common.Constant;
using ldtiep.be.Common.Resource;
using ldtiep.be.DL;
using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Model;
using ldtiep.be.DL.Repository;
using ldtiep.be.Enum;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System.Globalization;
using System.Reflection;
using ZaloPay.Helper; // HmacHelper, RSAHelper, HttpHelper, Utils (tải về ở mục DOWNLOADS)
using ZaloPay.Helper.Crypto;

namespace ldtiep.be.BL.Service
{
    /// <summary>
    /// Class dịch vụ cơ bản
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TEntityCreateDto"></typeparam>
    /// <typeparam name="TEntityUpdateDto"></typeparam>
    /// Author: LeDucTiep (23/05/2023)
    public class BaseService<TEntity, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto>
    {
        #region Field
        protected readonly IBaseRepository<TEntity> _baseRepository;

        protected IMSDatabase _msDatabase;

        protected readonly IMapper _mapper;
        #endregion

        #region Contructor 
        public BaseService(
            IMSDatabase msDatabase,
            IBaseRepository<TEntity> baseRepository,
            IMapper mapper)
        {
            _baseRepository = baseRepository;
            _msDatabase = msDatabase;
            _mapper = mapper;
        }
        #endregion

        #region Method
        /// <summary>
        /// Xóa một bản ghi theo id 
        /// </summary>
        /// <param name="id">Id của bản ghi </param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<int> DeleteAsync(Guid id)
        {
            _msDatabase.BeginTransaction();

            try
            {
                // Kiểm tra lỗi
                List<int> errorCodes = await DeleteValidate(id);
                if (errorCodes.Any())
                    throw new BadRequestException(errorCodes);

                /// Xóa 
                int changedCount = await _baseRepository.DeleteAsync(id);

                _msDatabase.Commit();

                return changedCount;
            }
            catch (Exception ex)
            {
                _msDatabase.Rollback();
                throw;
            }
            finally
            {
                await _msDatabase.CloseConnectionAsync();
            }
        }

        /// <summary>
        /// Xóa một bản ghi theo id 
        /// </summary>
        /// <param name="id">Id của bản ghi </param>
        /// <returns>Task</returns>
        /// <exception cref="NotFoundException">Lỗi không tìm thấy </exception>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<int> DeleteManyAsync(Guid[] arrayId)
        {
            _msDatabase.BeginTransaction();

            try
            {
                List<Guid> insertIds = new();

                foreach (var id in arrayId)
                {
                    // Kiểm tra lỗi
                    List<int> errorCodes = await DeleteValidate(id);
                    // Nếu không có lỗi
                    if (!errorCodes.Any())
                        insertIds.Add(id);
                }

                Guid[] deleteList = insertIds.ToArray();

                /// Xóa và nhận về mã lỗi 
                int changedCount = 0;

                if (deleteList.Length > 0)
                {
                    changedCount = await _baseRepository.DeleteManyAsync(deleteList);
                }

                _msDatabase.Commit();

                return changedCount;
            }
            catch (Exception ex)
            {
                _msDatabase.Rollback();
                throw;
            }
            finally
            {
                await _msDatabase.CloseConnectionAsync();
            }
        }

        /// <summary>
        /// Hàm lấy một bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi cần lấy </param>
        /// <returns>TEntityDto?</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<TEntityDto?> GetAsync(Guid id)
        {
            try
            {
                // Kiểm tra lỗi
                if (id.Equals(Guid.Empty))
                {
                    List<int> errorList = new() { (int)RequestErrorCode.GuidInvalid };
                    throw new BadRequestException(errorList);
                }

                // Thực hiện
                var entity = await _baseRepository.GetAsync(id);

                // Trả về
                var entityDto = _mapper.Map<TEntityDto>(entity);

                return entityDto;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                await _msDatabase.CloseConnectionAsync();
            }
        }

        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="entity">Loại bản ghi </param>
        /// <returns>TEntity</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<TEntityDto> PostAsync(TEntityCreateDto entity)
        {
            _msDatabase.BeginTransaction();

            try
            {
                TEntityDto entityDto = _mapper.Map<TEntityDto>(entity);

                List<int> errorCodes = new();

                errorCodes.AddRange(Validate(entityDto));

                try
                {
                    List<int> ints = await PostValidate(entityDto);

                    errorCodes.AddRange(ints);
                }
                catch { }


                if (errorCodes.Any())
                    throw new BadRequestException(errorCodes);

                TEntity entity1 = _mapper.Map<TEntity>(entity);

                int changedCount = await _baseRepository.PostAsync(entity1, Guid.NewGuid());

                if (changedCount == 0)
                    throw new InternalException();

                TEntityDto entity2 = _mapper.Map<TEntityDto>(entity1);

                _msDatabase.Commit();

                return entity2;
            }
            catch (Exception ex)
            {
                _msDatabase.Rollback();
                throw;
            }
            finally
            {
                await _msDatabase.CloseConnectionAsync();
            }
        }

        /// <summary>
        /// Hàm update một bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <param name="entity">Giá trị bản ghi</param>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<int> UpdateAsync(Guid id, TEntityUpdateDto entity)
        {
            _msDatabase.BeginTransaction();

            try
            {
                TEntityDto entityDto = _mapper.Map<TEntityDto>(entity);

                List<int> errorCodes = new();

                errorCodes.AddRange(Validate(entityDto));

                try
                {
                    errorCodes.AddRange(await UpdateValidate(id, entityDto));
                }
                catch { }

                if (errorCodes.Any())
                    throw new BadRequestException(errorCodes);

                // Thêm trường id để trả về
                TEntity _entity = _mapper.Map<TEntity>(entity);

                // Update
                int changedCount = await _baseRepository.UpdateAsync(id, _entity);

                _msDatabase.Commit();

                return changedCount;
            }
            catch (Exception ex)
            {
                _msDatabase.Rollback();
                throw;
            }
            finally
            {
                await _msDatabase.CloseConnectionAsync();
            }
        }

        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<IEnumerable<TEntityDto>> GetAllAsync()
        {
            try
            {
                // Gọi đến procedure
                IEnumerable<TEntity> myList = await _baseRepository.GetAllAsync();

                return _mapper.Map<IEnumerable<TEntityDto>>(myList);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                await _msDatabase.CloseConnectionAsync();
            }
        }

        /// <summary>
        /// Hàm validate
        /// </summary>
        /// Author: LeDucTiep (09/06/2023)
        public virtual List<int> Validate(TEntityDto entity)
        {
            List<int> errorCodes = new();

            if (entity == null)
            {
                return errorCodes;
            }

            System.Reflection.PropertyInfo[] properties = typeof(TEntityDto).GetProperties();

            foreach (System.Reflection.PropertyInfo property in properties)
            {
                var value = property.GetValue(entity, null);


                // Xét bắt buộc 
                var attributeRequired = (MSRequiredAttribute?)property.GetCustomAttributes(typeof(MSRequiredAttribute), false).FirstOrDefault();

                if (attributeRequired != null)
                {
                    if (value == null)
                        errorCodes.Add(attributeRequired.ErrorCode);
                    else if (property.PropertyType == typeof(Guid) && (Guid)value == Guid.Empty)
                        errorCodes.Add(attributeRequired.ErrorCode);
                    else if (property.PropertyType == typeof(string) && (string)value == string.Empty)
                        errorCodes.Add(attributeRequired.ErrorCode);

                }

                // Xét thông tin chỉ số 
                var attributeNumber = (MSNumberAttribute?)property.GetCustomAttributes(typeof(MSNumberAttribute), false).FirstOrDefault();

                if (attributeNumber != null && value != null && !MSNumberAttribute.IsValid(value))
                {
                    errorCodes.Add(attributeNumber.ErrorCode);
                }


                // Xét độ dài 
                var attributeMaxLength = (MSMaxLengthAttribute?)property.GetCustomAttributes(typeof(MSMaxLengthAttribute), false).FirstOrDefault();

                if (attributeMaxLength != null && value != null)
                {
                    int valueLength = value.ToString().Length;
                    int maxLength = attributeMaxLength.Length;
                    bool isTooLong = valueLength > maxLength;
                    if (isTooLong)
                    {
                        errorCodes.Add(attributeMaxLength.ErrorCode);
                    }
                }


                // Xét ngày tháng
                var validDateInThePast = (MSValidDateInThePastAttribute?)property.GetCustomAttributes(typeof(MSValidDateInThePastAttribute), false).FirstOrDefault();

                if (validDateInThePast != null && value != null && !MSValidDateInThePastAttribute.IsValid(value))
                {
                    errorCodes.Add(validDateInThePast.ErrorCode);
                }


                // Xét email
                var emailAttribute = (MSEmailAttribute?)property.GetCustomAttributes(typeof(MSEmailAttribute), false).FirstOrDefault();

                if (emailAttribute != null && !string.IsNullOrEmpty((string)value) && !MSEmailAttribute.IsValid(value))
                {
                    errorCodes.Add(emailAttribute.ErrorCode);
                }
            }

            return errorCodes;
        }

        /// <summary>
        /// Hàm validate theo từng loại service
        /// </summary>
        /// <typeparam name="T">Thực thể</typeparam>
        /// <param name="entity">Thực thể</param>
        /// Author: LeDucTiep (09/06/2023)
        public virtual async Task<List<int>> PostValidate(TEntityDto entity)
        {
            Task<List<int>> task = new(
                    () => new List<int>()
                );
            task.Start();

            // Trả về danh sách rỗng
            return await task;
        }

        /// <summary>
        /// Hàm validate theo từng loại service
        /// </summary>
        /// <typeparam name="T">Thực thể</typeparam>
        /// <param name="entity">Thực thể</param>
        /// <param name="id">Id của bản ghi</param>
        /// Author: LeDucTiep (09/06/2023)
        public virtual async Task<List<int>> UpdateValidate(Guid id, TEntityDto entity)
        {
            Task<List<int>> task = new(
                    () => new List<int>()
                );
            task.Start();

            // Trả về danh sách rỗng
            return await task;
        }

        /// <summary>
        /// Hàm validate theo từng loại service
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// Author: LeDucTiep (09/06/2023)
        public virtual async Task<List<int>> DeleteValidate(Guid id)
        {
            Task<List<int>> task = new(
                    () => new List<int>()
                );
            task.Start();

            // Trả về danh sách rỗng
            return await task;
        }

        static string app_id = "2553";
        static string key1 = "PcY4iZIKFCIdgZvA6ueMcMHHUbRLYjPL";
        static string create_order_url = "https://sb-openapi.zalopay.vn/v2/create";

        public virtual async Task<string> GenPaymentUrl(Dictionary<string, object> body)
        {
            string url = "";

            Random rnd = new();
            var embed_data = new { };
            var items = new[] { new { } };
            var param = new Dictionary<string, string>();
            var app_trans_id = rnd.Next(1000000); // Generate a random order's ID.

            param.Add("app_id", app_id);
            param.Add("app_user", "user123");
            param.Add("app_time", Utils.GetTimeStamp().ToString());
            param.Add("amount", body.GetValueOrDefault("requiredAmount")?.ToString() ?? "5000");
            param.Add("app_trans_id", DateTime.Now.ToString("yyMMdd") + "_" + app_trans_id); // mã giao dich có định dạng yyMMdd_xxxx
            param.Add("embed_data", JsonConvert.SerializeObject(embed_data));
            param.Add("item", JsonConvert.SerializeObject(items));
            param.Add("description", body.GetValueOrDefault("paymentContent")?.ToString() ?? "");
            param.Add("bank_code", "zalopayapp");

            var data = app_id + "|" + param["app_trans_id"] + "|" + param["app_user"] + "|" + param["amount"] + "|"
                + param["app_time"] + "|" + param["embed_data"] + "|" + param["item"];
            param.Add("mac", HmacHelper.Compute(ZaloPayHMAC.HMACSHA256, key1, data));

            var result = await HttpHelper.PostFormAsync(create_order_url, param);

            foreach (var entry in result)
            {
                Console.WriteLine("{0} = {1}", entry.Key, entry.Value);

                if(entry.Key == "order_url")
                {
                    return entry.Value.ToString();
                }
            }

            return url;
        }
        public virtual async Task<bool> CheckExistedAsync(Dictionary<string, string> param)
        {
            try
            {
                return await _baseRepository.CheckExistedAsync(param);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                await _msDatabase.CloseConnectionAsync();
            }
        }
        /// <summary>
        /// hàm lấy trang bản ghi
        /// </summary>
        /// <param name="basePagingArgument">Tham số để phân trang</param>
        /// <returns>Trang bản ghi</returns>
        /// Author: LeDucTiep (12/07/2023)
        public virtual async Task<BasePage<TEntityDto>> GetPageAsync(BasePagingArgument basePagingArgument)
        {
            try
            {
                List<int> errorCodes = new();

                // Lỗi kích thước trang 
                if (basePagingArgument.PageSize <= 0)
                {
                    errorCodes.Add((int)PagingErrorCode.InvalidPageSize);
                }

                // Lỗi số thứ tự trang 
                if (basePagingArgument.PageNumber <= 0)
                {
                    errorCodes.Add((int)PagingErrorCode.InvalidPageNumber);
                }

                // Kiểm tra độ dài chuỗi tìm kiếm 
                PropertyInfo[] properties = typeof(BasePagingArgument).GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    var value = property.GetValue(basePagingArgument, null);

                    // Lỗi độ dài từ khóa tìm kiếm
                    var attributeMaxLength = (MSMaxLengthAttribute?)property.GetCustomAttributes(typeof(MSMaxLengthAttribute), false).FirstOrDefault();

                    if (attributeMaxLength != null && value != null && value.ToString().Length > attributeMaxLength.Length)
                    {
                        errorCodes.Add(attributeMaxLength.ErrorCode);
                    }
                }

                // Nếu có lỗi 
                if (errorCodes.Count > 0)
                    throw new BadRequestException(errorCodes);

                BasePage<TEntityDto> page = await _baseRepository.GetPageAsync<TEntityDto>(basePagingArgument);

                return page;

            }

            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                await _msDatabase.CloseConnectionAsync();
            }
        }
        #endregion
    }
}
