using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.WebHost.Controllers.Base;
using GMS.Core.WebHost.Models;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Core.WebHost.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : BaseController<IAreaService>
    {
        public AreaController(IAreaService service, ILogger<AreaController> logger, IMapper mapper) 
            : base(service, logger, mapper) { }

        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPage(Guid fitnessClubId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(AreaRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Edit(Guid id, AreaRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
