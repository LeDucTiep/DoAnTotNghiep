using ldtiep.be.DL.Entity;

namespace ldtiep.be.DL.Repository
{
    public class ColorRepository : BaseRepository<Color>, IColorRepository
    {
        public ColorRepository(IMSDatabase msDatabase) : base(msDatabase)
        {
        }
    }
}
