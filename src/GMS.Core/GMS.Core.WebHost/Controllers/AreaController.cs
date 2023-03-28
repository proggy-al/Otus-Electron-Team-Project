using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Controllers.Base;
using GMS.Core.WebHost.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
            var pagedList = await _service.GetPage(fitnessClubId, pageNumber, pageSize);
            var result = _mapper.Map<List<AreaResponse>>(pagedList.Entities);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedList.Pagination));

            int cnt = result.Count;

            _logger.LogInformation($"Returned {cnt} Area{(cnt > 1 ? "s" : "")} from database.");

            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var areaDto = await _service.Get(id);
            var result = _mapper.Map<AreaResponse>(areaDto);

            _logger.LogInformation($"Returned Area \"{id}\" from database.");

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(AreaCreateRequest request)
        {
            var areaDto = _mapper.Map<AreaCreateDto>(request);
            areaDto.EmploeeId = UserId;

            var id = await _service.Create(areaDto);

            _logger.LogInformation($"Add Area \"{id}\" to database.");

            return Ok(id.ToString());
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Edit(Guid id, AreaEditRequest request)
        {
            var areaDto = _mapper.Map<AreaEditDto>(request);
            areaDto.EmploeeId = UserId;

            await _service.Update(id, areaDto);

            _logger.LogInformation($"Edit Area \"{id}\" in database");

            return NoContent();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> AddToArchive(Guid id)
        {
            await _service.AddToArchive(id, UserId);

            _logger.LogInformation($"Add to archive Area \"{id}\"");

            return NoContent();
        }
    }
}
