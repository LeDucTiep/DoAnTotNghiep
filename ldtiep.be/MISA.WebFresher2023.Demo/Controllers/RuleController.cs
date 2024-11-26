using Microsoft.AspNetCore.Mvc;
using ldtiep.be.BL.Dto;
using ldtiep.be.BL.Service;
using ldtiep.be.Controllers;
using ldtiep.be.DL.Entity;

namespace ldtiep.be.api.Controllers
{
    [Route("api/v1/[controller]s")]
    public class RuleController : BaseController<Rule, RuleDto, RuleCreateDto, RuleUpdateDto>
    {
        public IRuleService _sizeService;
        public RuleController(IRuleService sizeService
            ) : base(sizeService)
        {
            _sizeService = sizeService;
        }
    }
}
