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
    [Route("areas")]
    [ApiController]
    public class AreaController : 
        BaseController<AreaController, IAreaService, Area, AreaDto, AreaVM, Guid>
    {
        public AreaController(IAreaService service, ILogger<AreaController> logger, IMapper mapper)
            : base(service, logger, mapper) { }

        /// <summary>
        /// Получение областей с пагинацией
        /// </summary>
        /// <param name="limit">Количество сущностей</param>
        /// <param name="offset">Индекс начала выборки</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPage(int? limit, int? offset)
        {
            limit = limit ?? int.MaxValue;
            offset = offset ?? 0;

            var entitiesDto = await _service.GetPage(limit.Value, offset.Value);

            if (entitiesDto == null)
                return NotFound();

            return Ok(_mapper.Map<List<AreaVM>>(entitiesDto));
        }


        /// <summary>
        /// Поулчение фитнес клубов с пагинацией 
        /// </summary>
        /// <param name="fitnessClubId">Идентификатор фитнес клуба</param>
        /// <param name="limit">Количество сущностей</param>
        /// <param name="offset">>Индекс начала выборки</param>
        /// <returns></returns>
        [HttpGet("{fitnessClubId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPageByFitnessClubId(Guid fitnessClubId, int? limit, int? offset)
        {
            limit = limit ?? int.MaxValue;
            offset = offset ?? 0;

            var entitiesDto = await _service.GetPageByFitnessClubId(fitnessClubId, limit.Value, offset.Value);

            if (entitiesDto == null)
                return NotFound();

            return Ok(_mapper.Map<List<AreaVM>>(entitiesDto));
        }
    }
}
