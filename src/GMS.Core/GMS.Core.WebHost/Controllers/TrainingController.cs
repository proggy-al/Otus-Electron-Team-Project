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
    public class TrainingController :
        BaseController<TrainingController, ITrainingService, Training, TrainingDto, TrainingVM, Guid>
    {
        public TrainingController(ITrainingService service, ILogger<TrainingController> logger, IMapper mapper)
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

            return Ok(_mapper.Map<List<TrainingVM>>(entitiesDto));
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByUserId(Guid userId)
        {
            var entitiesDto = await _service.GetAllByUserId(userId);

            if (entitiesDto == null)
                return NotFound();

            return Ok(_mapper.Map<List<TrainingVM>>(entitiesDto));
        }

        [HttpGet("[action]/{page}:{itemsPerPage}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPageByUserId(Guid userId, int page, int itemsPerPage)
        {
            var entitiesDto = await _service.GetPageByUserId(userId, page, itemsPerPage);

            if (entitiesDto == null)
                return NotFound();

            return Ok(_mapper.Map<List<TrainingVM>>(entitiesDto));
        }
    }
}
