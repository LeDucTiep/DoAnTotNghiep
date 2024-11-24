using Dapper;
using ldtiep.be.Common;
using System.Data;
using ldtiep.be.DL.Entity;
using static Dapper.SqlMapper;

namespace ldtiep.be.DL.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IMSDatabase msDatabase) : base(msDatabase)
        {
        }
    }
}
