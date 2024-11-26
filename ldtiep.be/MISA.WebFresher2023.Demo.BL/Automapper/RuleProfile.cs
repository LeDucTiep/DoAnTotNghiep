using AutoMapper;
using ldtiep.be.BL.Dto;
using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Model;

namespace ldtiep.be.BL
{
    /// <summary>
    /// Class dành cho automapper 
    /// </summary>
    /// Author: LeDucTiep (07/06/2023)
    public class RuleProfile : Profile
    {
        public RuleProfile()
        {
            CreateMap<Rule, RuleDto>();
            CreateMap<RuleDto, Rule>();
            CreateMap<Rule, RuleCreateDto>();
            CreateMap<RuleCreateDto, RuleDto>();
            CreateMap<RuleCreateDto, Rule>();
            CreateMap<RuleDto, RuleCreateDto>();
            CreateMap<RuleUpdateDto, Rule>();
            CreateMap<RuleUpdateDto, RuleDto>();
            CreateMap<RuleDto, RuleUpdateDto>();
            CreateMap<Rule, RuleUpdateDto>();
            CreateMap<BasePage<Rule>, BasePage<RuleDto>>();
        }
    }
}
