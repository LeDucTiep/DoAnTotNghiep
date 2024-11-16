using ldtiep.be.DL.Entity;

namespace ldtiep.be.DL.Repository
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(IMSDatabase msDatabase) : base(msDatabase)
        {
        }
    }
}
