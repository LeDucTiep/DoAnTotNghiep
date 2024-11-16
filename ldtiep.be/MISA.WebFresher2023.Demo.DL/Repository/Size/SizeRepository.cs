using ldtiep.be.DL.Entity;

namespace ldtiep.be.DL.Repository
{
    public class SizeRepository : BaseRepository<Size>, ISizeRepository
    {
        public SizeRepository(IMSDatabase msDatabase) : base(msDatabase)
        {
        }
    }
}
