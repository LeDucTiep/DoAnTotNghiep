using AutoMapper;
using ldtiep.be.BL.Dto;
using ldtiep.be.DL;
using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Repository;

namespace ldtiep.be.BL.Service
{
    public class DistrictService : BaseService<District, DistrictDto, DistrictCreateDto, DistrictUpdateDto>, IDistrictService
    {
        public DistrictService(
            IDistrictRepository sizeRepository,
           
            IMSDatabase msDatabase,
            IMapper mapper) : base(msDatabase, sizeRepository, mapper)
        {
           
        }
    }
}
