using ldtiep.be.DL.Entity;

namespace ldtiep.be.DL.Repository
{
    public class CommuneRepository : BaseRepository<Commune>, ICommuneRepository
    {
        public CommuneRepository(IMSDatabase msDatabase) : base(msDatabase)
        {
        }
    }
}
