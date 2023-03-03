using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.UseCases.Area;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Core.WebHost.Controllers
{
    [ApiController]
    [Route("api/area-rebuild")]
    public class AreaRebuildController : Controller
    {
        private readonly ISender mediator;

        public AreaRebuildController(ISender mediator = null)
        {
            this.mediator = mediator;
        }


        [HttpGet()]
        public async Task<ActionResult<IEnumerable<AreaDto>>> GetArea(Guid fitnessClubId = default, int page = 0, int pageSize = 0)
        {
            return Ok(await mediator.Send(new GetAreaCase(fitnessClubId, page, pageSize)));
        }
    }
}
