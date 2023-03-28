using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.WebHost.Controllers.Base;
using GMS.Core.WebHost.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Core.WebHost.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : BaseController<ITrainingService>
    {
        public TrainingController(ITrainingService service, ILogger<TrainingController> logger, IMapper mapper) : base(service, logger, mapper) { }

        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPage(int pageNumber, int pageSize = 12)
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> AddTrainerNotes(TrainingTrainerNotes request)
        {
            throw new NotImplementedException();
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> AddUserSignedUp(TrainingUserSignedUp request)
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
