using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Controllers.Base;
using GMS.Core.WebHost.VIewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Core.WebHost.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessClubController : 
        BaseController<FitnessClubController, IFitnessClubService, FitnessClub, FitnessClubDto, FitnessClubVM, Guid>
    {
        public FitnessClubController(IFitnessClubService service, ILogger<FitnessClubController> logger, IMapper mapper) 
            : base(service, logger, mapper) { }

        [HttpGet("[action]/{page}:{itemsPerPage}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPage(int page, int itemsPerPage)
        {
            var entitiesDto = await _service.GetPage(page, itemsPerPage);

            if (entitiesDto == null)
                return NotFound();

            return Ok(_mapper.Map<List<FitnessClubVM>>(entitiesDto));
        }
    }
}
