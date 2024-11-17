using Dapper;
using ldtiep.be.Common;
using ldtiep.be.Common.Resource;
using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Model;
using ldtiep.be.Enum;
using System;
using System.Data;
using System.Linq;
using System.Net;

namespace ldtiep.be.DL.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        #region Field
        /// <summary>
        /// Chuỗi kết nối 
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        protected readonly IMSDatabase _msDatabase;
        #endregion

        #region Contructor
        public BaseRepository(IMSDatabase msDatabase)
        {
            _msDatabase = msDatabase;
        }
        #endregion

        #region Method

        public async Task InsertProduct(Product product)
        {
            // Tạo connection
            var connection = await _msDatabase.GetOpenConnectionAsync();

            string sql = $"select 0;";

            // Gọi procedure 
            await connection.QueryAsync<Product>(sql);
        }

        /// <summary>
        /// Hàm xóa một bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<int> DeleteAsync(Guid id)
        {
            // Tên bảng 
            var table = typeof(TEntity).Name;
            var whereBlock = new List<string>();

            // Connection với database 
            var connection = await _msDatabase.GetOpenConnectionAsync();

            try
            {
                // Khởi tạo các tham số 
                var dynamicParams = new DynamicParameters();
                dynamicParams.Add($"v_{table}ID", id);
                whereBlock.Add($"{table}ID = @v_{table}ID");

                string where = string.Join(" and ", whereBlock);

                string query = $"delete from ldt_{table} where {where} ;";

                var countChanged = await connection.ExecuteAsync(
                    query,
                    param: dynamicParams,
                    commandType: CommandType.Text
                );

                return countChanged;
            }
            catch (Exception ex)
            {
                throw new InternalException();
            }

        }

        /// <summary>
        /// Hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<int> DeleteManyAsync(Guid[] arrayId)
        {
            // Số lượng bản ghi bị xóa
            int countChanged = 0;

            // Tên bảng 
            var table = typeof(TEntity).Name;

            // Connection với database 
            var connection = await _msDatabase.GetOpenConnectionAsync();

            try
            {
                // Chuyển thành dạng danh sách
                List<Guid> listId = arrayId.ToList();

                // Còn thở thì còn xóa
                while (listId.Count > 0)
                {
                    var whereBlock = new List<string>() { "true"};
                    var ids = new List<string>();

                    // Xóa mỗi lần 10 bản ghi
                    while (listId.Count > 0)
                    {
                        Guid guid = listId[0];

                        ids.Add($"'{guid}'");

                        listId.RemoveAt(0);
                    }

                    string param = string.Join(",", ids);

                    whereBlock.Add($"{table}ID in ({param})");

                    string where = string.Join(" and ", whereBlock);

                    string query = $"delete from ldt_{table.ToLower()} where {where}";

                    countChanged += await connection.ExecuteAsync(
                        query,
                        commandType: CommandType.Text
                    );
                }
                return countChanged;
            }
            catch (Exception ex)
            {
                throw new InternalException();
            }
        }

        /// <summary>
        /// Hàm lấy một bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <returns>Giá trị của bản ghi</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<TEntity?> GetAsync(Guid id)
        {
            // Tên bảng
            var table = typeof(TEntity).Name;

            // Kết nối với database
            var connection = await _msDatabase.GetOpenConnectionAsync();

            try
            {
                // Tham số 
                var dynamicParams = new DynamicParameters();
                dynamicParams.Add($"v_{table}ID", id);

                string query = $"select * from ldt_{table.ToLower()} where {table}ID = @v_{table}ID;";

                // Bản ghi trả về 
                var entity = await connection.QueryFirstOrDefaultAsync<TEntity>(
                    query,
                    param: dynamicParams,
                    commandType: CommandType.Text
                );

                return entity;
            }
            catch (Exception ex)
            {
                throw new InternalException();
            }
        }

        /// <summary>
        /// Hàm thêm một bản ghi
        /// </summary>
        /// <param name="entity">Giá trị của bản ghi</param>
        /// <returns>Mã lỗi</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<int> PostAsync(TEntity entity, Guid newId)
        {
            // Tên bảng
            var table = typeof(TEntity).Name;

            // Mở kết nối tới database
            var connection = await _msDatabase.GetOpenConnectionAsync();

            // Các tham số
            var dynamicParams = new DynamicParameters();
            var valueBlocks = new List<string>();
            var fieldBlocks = new List<string>();

            var properties = entity.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo property in properties)
            {
                // Tên thuộc tính
                var name = property.Name;

                // Gán id mới
                if (name == $"{table}ID")
                {
                    property.SetValue(entity, newId, null);

                    dynamicParams.Add($"v_{table}ID", newId);
                    valueBlocks.Add($"@v_{table}ID");
                    fieldBlocks.Add($"{table}ID");
                    continue;
                }

                // Bỏ qua ngày sửa và người sửa 
                if (name == "ModifiedBy" || name == "ModifiedDate")
                    continue;

                // Giá trị của tham số 
                object? value = property.GetValue(entity);

                if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                {
                    if (value != null && value.Equals(Guid.Empty))
                    {
                        value = null;
                    }
                }

                // Thêm tham số 
                dynamicParams.Add($"v_{name}", value);
                valueBlocks.Add($"@v_{name}");
                fieldBlocks.Add(name);
            }

            try
            {
                string values = string.Join(" , ", valueBlocks);
                string fields = string.Join(" , ", fieldBlocks);
                string query = $"insert into ldt_{table.ToLower()}({fields}) values ({values});";
                //Gọi procedure
                int changedCount = await connection.ExecuteAsync(
                    query,
                    param: dynamicParams,
                    commandType: CommandType.Text
                );

                return changedCount;
            }
            catch (Exception ex)
            {
                throw new InternalException();
            }
        }

        /// <summary>
        /// Hàm update một bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <param name="entity">Giá trị của bản ghi</param>
        /// <returns>Mã lỗi</returns>
        /// Author: LeDucTiep (23/05/2023)
        public virtual async Task<int> UpdateAsync(Guid id, TEntity entity)
        {
            // Tên bảng 
            var table = typeof(TEntity).Name;

           
            string tableName = $"ldt_{table.ToLower()}";


            // Mở kết nối tới database
            var connection = await _msDatabase.GetOpenConnectionAsync();
            // Khởi tạo tham số 
            var dynamicParams = new DynamicParameters();
            var setBlock = new List<string>();
            var whereBlock = new List<string>();

            // Duyệt qua tất cả thuộc tính của entity
            System.Reflection.PropertyInfo[] properties = entity.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo property in properties)
            {
                // Tên tham số
                var name = property.Name;

                // Gán id truyền vào 
                if (name == $"{table}ID")
                {
                    dynamicParams.Add($"v_{table}ID", id);
                    whereBlock.Add($"{table}ID = @v_{table}ID");
                    continue;
                }

                // Bỏ qua người tạo và ngày tạo
                if (name == "CreatedBy" || name == "CreatedDate")
                    continue;

                // Giá trị của tham số 
                var value = property.GetValue(entity);

                if (value != null && value.Equals(Guid.Empty))
                {
                    value = null;
                }

                // Thêm tham số
                dynamicParams.Add($"v_{name}", value);

                setBlock.Add($"{name} = @v_{name}");
            }

            try
            {
                string whereCmd = string.Join(" and ", whereBlock);
                string setCmd = string.Join(" , ", setBlock);
                string query = $"update {tableName} set {setCmd} where {whereCmd} ;";

                // Gọi update
                int changedCount = await connection.ExecuteAsync(
                    query,
                    param: dynamicParams,
                    commandType: CommandType.Text
                );

                return changedCount;
            }
            catch (Exception ex)
            {
                throw new InternalException();
            }
        }

        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Author: LeDucTiep (27/05/2023)
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            // Tên bảng
            var table = typeof(TEntity).Name;

            // Tạo connection
            var connection = await _msDatabase.GetOpenConnectionAsync();
            try
            {
                // Tên procedure
                string procedure = ProcedureResource.GetAll(table);

                // Gọi đến procedure
                return await connection.QueryAsync<TEntity>(
                    procedure,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                throw new InternalException();
            }
        }

        /// <summary>
        /// Hàm kiểm tra bản ghi có tồn tại không
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <param name="table">Tên table</param>
        /// <returns>bool</returns>
        /// Author: LeDucTiep (12/07/2023)
        public async Task<bool> CheckExistedAsync(Dictionary<string, string> param)
        {
            // Tên bảng
            string table = typeof(TEntity).Name;

            // Kết nối với database
            var connection = await _msDatabase.GetOpenConnectionAsync();

            try
            {
                var whereBlock = new List<string>() { "1 = 1"};
                var dynamicParams = new DynamicParameters();

                foreach (var item in param.Keys)
                {
                    string val = param.GetValueOrDefault(item);

                    if (!string.IsNullOrEmpty(val))
                    {
                        whereBlock.Add($"{item} = @v_{item}");

                        // Tham số 
                        dynamicParams.Add($"v_{item}", val);
                    }
                }


                string where = string.Join(" and ", whereBlock);
                string query = $"select exists(select * from ldt_{table} where {where})";

                // Bản ghi trả về 
                bool isExists = await connection.QueryFirstAsync<bool>(
                        query,
                        param: dynamicParams,
                        commandType: CommandType.Text
                    );

                return isExists;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Hàm lấy trang bản ghi
        /// </summary>
        /// <typeparam name="TEntityInPage">Loại bản ghi trong trang</typeparam>
        /// <param name="basePagingArgument">Tham số để phân trang</param>
        /// <returns>BasePage<TEntityInPage></returns>
        /// Author: LeDucTiep (08/05/2023)
        public virtual async Task<BasePage<TEntityInPage>> GetPageAsync<TEntityInPage>(BasePagingArgument basePagingArgument)
        {
            // Tạo connection
            var connection = await _msDatabase.GetOpenConnectionAsync();

            string tableName = typeof(TEntity).Name;
            var whereBlocks = new List<string>()
            {
                " true "
            };

            // Tạo tham số đầu vào 
            // IN _offset: Số bản ghi bị bỏ qua
            // IN _limit: Số bản ghi được lấy
            // IN employeeSearchTerm: Từ khóa tìm kiếm, theo employeeCode hoặc FullName
            // OUT TotalRecord: Tổng số bản ghi tìm thấy
            var parameters = new DynamicParameters();
            int offset = (basePagingArgument.PageNumber - 1) * basePagingArgument.PageSize;
            parameters.Add("v_offset", offset);
            parameters.Add("v_limit", basePagingArgument.PageSize);

            if(basePagingArgument.SearchTerm?.Keys != null)
            {
                foreach (var key in basePagingArgument.SearchTerm.Keys)
                {
                    whereBlocks.Add($"{key} = @v_{key}");
                    parameters.Add(key, basePagingArgument.SearchTerm.GetValueOrDefault(key));
                }
            }
            try
            {
                string where = string.Join(" and ", whereBlocks);
                string query = $"select * from ldt_{tableName.ToLower()} where {where} limit @v_limit offset @v_offset;";

                // Gọi procedure 
                IEnumerable<TEntityInPage> res = await connection.QueryAsync<TEntityInPage>(
                    query,
                    param: parameters,
                    commandType: CommandType.Text
                );


                string queryTotal = $"select count(*) from ldt_{tableName.ToLower()} where {where};";

                // Lấy tổng số trang 
                int totalRecord = await connection.QueryFirstOrDefaultAsync<int>(
                    queryTotal,
                    param: parameters,
                    commandType: CommandType.Text
                );

                // trả về kết quả
                return new BasePage<TEntityInPage>(totalRecord, res);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return null;
            }
        }

        #endregion
    }
}
