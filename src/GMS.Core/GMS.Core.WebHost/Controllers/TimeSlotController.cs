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
    [Route("time-slots")]
    [ApiController]
    public class TimeSlotController :
        BaseController<TimeSlotController, ITimeSlotService, TimeSlot, TimeSlotDto, TimeSlotVM, Guid>
    {
        public TimeSlotController(ITimeSlotService service, ILogger<TimeSlotController> logger, IMapper mapper) 
            : base(service, logger, mapper) { }

        /// <summary>
        /// Получение слотов тренера в фитнес клуба
        /// </summary>
        /// <param name="date">Дата</param>
        /// <param name="fitnessClubId">Индентификатор фитнес клуба</param>
        /// <param name="trainerId">Идентификатор тренера</param>
        /// <returns></returns>
        [HttpGet("{fitnessClubId:guid}/trainers/{trainerId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllPerDay(DateOnly date, Guid fitnessClubId, Guid trainerId)
        {
            var entitiesDto = await _service.GetAllPerDay(date, fitnessClubId, trainerId);

            if (entitiesDto == null)
                return NotFound();

            return Ok(_mapper.Map<List<TimeSlotVM>>(entitiesDto));
        }
    }
}
