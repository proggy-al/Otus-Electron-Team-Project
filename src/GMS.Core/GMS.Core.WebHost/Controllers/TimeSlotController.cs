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
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : BaseController<ITimeSlotService>
    {
        public TimeSlotController(ITimeSlotService service, ILogger<TimeSlotController> logger, IMapper mapper) : base(service, logger, mapper){ }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPerDay(DateOnly date, Guid fitnessClubId, Guid trainerId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]/{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(TimeSlotRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Edit(Guid id, TimeSlotRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            // поместить в архив связную Training
            // ToDo: отправить оповещение пользователю об отмене тренировки
            throw new NotImplementedException();
        }
    }
}
