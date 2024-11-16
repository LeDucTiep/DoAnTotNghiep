using Dapper;
using ldtiep.be.Common;
using System.Data;
using ldtiep.be.DL.Entity;
using static Dapper.SqlMapper;

namespace ldtiep.be.DL.Repository
{
    public class ColorRepository : BaseRepository<Color>, IColorRepository
    {
        public ColorRepository(IMSDatabase msDatabase) : base(msDatabase)
        {
        }
    }
}
