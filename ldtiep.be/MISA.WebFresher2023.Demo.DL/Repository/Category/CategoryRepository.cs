using ldtiep.be.DL.Entity;

namespace ldtiep.be.DL.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IMSDatabase msDatabase) : base(msDatabase)
        {
        }
    }
}
