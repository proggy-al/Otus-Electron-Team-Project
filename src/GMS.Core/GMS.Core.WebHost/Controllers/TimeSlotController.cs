using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Controllers.Base;
using GMS.Core.WebHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Core.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : BaseController<ITimeSlotService>
    {
        public TimeSlotController(ITimeSlotService service, IMapper mapper) : base(service, mapper){ }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPerDay([FromQuery]DateOnly date, [FromQuery]Guid trainerId)
        {
            var timeSlots = await _service.GetAllPerDay(date, trainerId);

            var result = _mapper.Map<List<TimeSlotResponse>>(timeSlots);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            var timeSlotDto = await _service.Get(id);
            var result = _mapper.Map<TimeSlotResponse>(timeSlotDto);

            return Ok(result);
        }

        [Authorize(Policy = "Manager")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(TimeSlotCreateRequest request)
        {
            var timeSlotDto = _mapper.Map<TimeSlotCreateDto>(request);
            timeSlotDto.UserId = UserId;

            var id = await _service.Create(timeSlotDto);
            return Ok(id.ToString());
        }

        [Authorize(Policy = "Administrator")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.AddToArchive(id, UserId);

            // ToDo: отправить оповещение пользователю об отмене тренировки

            return NoContent();
        }
    }
}
