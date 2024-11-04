using AutoMapper;
using ldtiep.be.BL.Dto;
using ldtiep.be.DL;
using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Repository;

namespace ldtiep.be.BL.Service
{
    public class ProductService : BaseService<Product, ProductDto, ProductCreateDto, ProductUpdateDto>, IProductService
    {
        public ProductService(
            IProductRepository productRepository,
           
            IMSDatabase msDatabase,
            IMapper mapper) : base(msDatabase, productRepository, mapper)
        {
           
        }
    }
}
