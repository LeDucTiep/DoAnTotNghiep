using Dapper;
using ldtiep.be.Common;
using System.Data;
using ldtiep.be.DL.Entity;
using static Dapper.SqlMapper;

namespace ldtiep.be.DL.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IMSDatabase msDatabase) : base(msDatabase)
        {
        }
        public async Task<string> ChangePassword(string sessionID, string newPass)
        {
            var table = typeof(Employee).Name;

            string tableName = $"ldt_{table.ToLower()}";

            // Mở kết nối tới database
            var connection = await _msDatabase.GetOpenConnectionAsync();
            var dynamicParams = new DynamicParameters();

            dynamicParams.Add("@ss", sessionID);

            string hashed = PasswordHasher.HashPassword(newPass);

            dynamicParams.Add("@pass", hashed);

            try
            {
                string query = $"update {tableName} set Password = @pass where SessionID = @ss limit 1;";

                // Gọi update
                await connection.ExecuteAsync(
                         query,
                         param: dynamicParams,
                         commandType: CommandType.Text
                     );

                return "";
            }
            catch (Exception ex)
            {
                throw new InternalException();
            }
        }
        public async Task<string> CheckPassword(string Password, string EmployeeCode)
        {
            var table = typeof(Employee).Name;

            string tableName = $"ldt_{table.ToLower()}";

            // Mở kết nối tới database
            var connection = await _msDatabase.GetOpenConnectionAsync();
            var dynamicParams = new DynamicParameters();

            dynamicParams.Add("@code", EmployeeCode);

            try
            {
                string query = $"select * from {tableName} where EmployeeCode = @code limit 1;";

                // Gọi update
                var employee = (await connection.QueryAsync<Employee>(
                        query,
                        param: dynamicParams,
                        commandType: CommandType.Text
                    )).ToList();

                if (employee.Count == 0)
                    return "";

                var em = employee.First();

                bool isOK = PasswordHasher.VerifyPassword(Password, em.Password);

                if (!isOK)
                {
                    return "";
                }

                em.SessionID = Guid.NewGuid();

                await this.UpdateAsync(em.EmployeeID, em);

                return em.SessionID?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                throw new InternalException();
            }
        }

        public async Task<Employee> GetUserInfor(string sessionID)
        {
            if (string.IsNullOrWhiteSpace(sessionID)) return new();

            var table = typeof(Employee).Name;

            string tableName = $"ldt_{table.ToLower()}";

            // Mở kết nối tới database
            var connection = await _msDatabase.GetOpenConnectionAsync();
            var dynamicParams = new DynamicParameters();

            dynamicParams.Add("@ss", sessionID);

            try
            {
                string query = $"select * from {tableName} where SessionID = @ss limit 1;";

                // Gọi update
                var employee = (await connection.QueryAsync<Employee>(
                        query,
                        param: dynamicParams,
                        commandType: CommandType.Text
                    )).ToList();

                if (employee.Count == 0)
                    return new();

                var em = employee.First();

                return em;
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
        public override async Task<int> UpdateAsync(Guid id, Employee entity)
        {
            // Tên bảng 
            var table = typeof(Employee).Name;


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

                if (name == "Password")
                    continue;

                if (name == "ModifiedDate")
                    value = DateTime.Now;

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
        /// Hàm thêm một bản ghi
        /// </summary>
        /// <param name="entity">Giá trị của bản ghi</param>
        /// <returns>Mã lỗi</returns>
        /// Author: LeDucTiep (23/05/2023)
        public override async Task<int> PostAsync(Employee entity, Guid newId)
        {
            // Tên bảng
            var table = typeof(Employee).Name;

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

                if (name == "CreatedDate")
                    value = DateTime.Now;

                if (name == "Password")
                    value = PasswordHasher.HashPassword("123456@");

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
    }
}
