using ldtiep.be.DL.Entity;

namespace ldtiep.be.DL.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IMSDatabase msDatabase) : base(msDatabase)
        {
        }
    }
}
