using ldtiep.be.Common;
using ldtiep.be.DL.Entity;
using static Dapper.SqlMapper;

namespace ldtiep.be.DL.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMSDatabase msDatabase) : base(msDatabase)
        {
        }

    }
}
