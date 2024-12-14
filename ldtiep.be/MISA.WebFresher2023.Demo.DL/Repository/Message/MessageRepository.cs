using Dapper;
using ldtiep.be.Common;
using System.Data;
using ldtiep.be.DL.Entity;
using static Dapper.SqlMapper;

namespace ldtiep.be.DL.Repository
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(IMSDatabase msDatabase) : base(msDatabase)
        {
        }

        public async Task<List<object>> GetChats()
        {
            // Kết nối với database
            var connection = await _msDatabase.GetOpenConnectionAsync();

            try
            {
                // Tham số 
                var dynamicParams = new DynamicParameters();

                string query = $"select distinct UserID from ldt_message;";

                // Bản ghi trả về 
                var entity = await connection.QueryAsync<object>(
                    query,
                    commandType: CommandType.Text
                );

                return entity.ToList();
            }
            catch (Exception ex)
            {
                throw new InternalException();
            }
        }
    }
}
