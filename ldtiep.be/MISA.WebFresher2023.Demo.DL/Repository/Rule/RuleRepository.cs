using Dapper;
using ldtiep.be.Common;
using System.Data;
using ldtiep.be.DL.Entity;
using static Dapper.SqlMapper;

namespace ldtiep.be.DL.Repository
{
    public class RuleRepository : BaseRepository<Entity.Rule>, IRuleRepository
    {
        public RuleRepository(IMSDatabase msDatabase) : base(msDatabase)
        {
        }
    }
}
