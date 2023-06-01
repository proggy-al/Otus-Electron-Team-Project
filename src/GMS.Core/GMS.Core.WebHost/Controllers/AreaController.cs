using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Controllers.Base;
using GMS.Core.WebHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GMS.Core.WebHost.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : BaseController<IAreaService>
    {
        public AreaController(IAreaService service, IMapper mapper) : base(service, mapper) { }

        /// <summary>
        /// Return list of Areas in fitness club
        /// </summary>
        /// <param name="fitnessClubId"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPage(Guid fitnessClubId, int pageNumber = 1, int pageSize = 12)
        {
            var pagedList = await _service.GetPage(fitnessClubId, pageNumber, pageSize);
            var result = _mapper.Map<List<AreaResponse>>(pagedList.Entities);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedList.Pagination));
            return Ok(result);
        }

        /// <summary>
        /// Get Area by Id
        /// AllowAnonymous request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var areaDto = await _service.Get(id);
            var result = _mapper.Map<AreaResponse>(areaDto);

            return Ok(result);
        }
        /// <summary>
        /// Create area in GYM
        /// Should be outhorize as Administrator
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Policy = "Administrator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(AreaCreateRequest request)
        {
            var areaDto = _mapper.Map<AreaCreateDto>(request);
            areaDto.EmployeeId = UserId;

            var id = await _service.Create(areaDto);

            return Ok(id.ToString());
        }

        /// <summary>
        /// Edit area in GYM by areaID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Policy = "Administrator")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Edit(Guid id, AreaEditRequest request)
        {
            var areaDto = _mapper.Map<AreaEditDto>(request);
            areaDto.EmployeeId = UserId;

            await _service.Update(id, areaDto);

            return NoContent();
        }

        /// <summary>
        /// Delete Area in  GYM by Area ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Policy = "Administrator")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> AddToArchive(Guid id)
        {
            await _service.AddToArchive(id, UserId);

            return NoContent();
        }
    }
}
