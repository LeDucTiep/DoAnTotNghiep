using ldtiep.be.DL.Entity;

namespace ldtiep.be.DL.Repository
{
    public class DistrictRepository : BaseRepository<District>, IDistrictRepository
    {
        public DistrictRepository(IMSDatabase msDatabase) : base(msDatabase)
        {
        }
    }
}
