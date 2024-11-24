using AutoMapper;
using ldtiep.be.BL.Dto;
using ldtiep.be.DL;
using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Repository;

namespace ldtiep.be.BL.Service
{
    public class CityService : BaseService<City, CityDto, CityCreateDto, CityUpdateDto>, ICityService
    {
        public CityService(
            ICityRepository sizeRepository,
           
            IMSDatabase msDatabase,
            IMapper mapper) : base(msDatabase, sizeRepository, mapper)
        {
           
        }
    }
}
