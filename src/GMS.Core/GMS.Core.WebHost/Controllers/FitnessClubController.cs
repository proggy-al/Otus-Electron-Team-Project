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
    [Route("fitness-clubs")]
    [ApiController]
    public class FitnessClubController : 
        BaseController<FitnessClubController, IFitnessClubService, FitnessClub, FitnessClubDto, FitnessClubVM, Guid>
    {
        public FitnessClubController(IFitnessClubService service, ILogger<FitnessClubController> logger, IMapper mapper) 
            : base(service, logger, mapper) { }

        /// <summary>
        /// Получение фитнес клубов с пагинацией
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

            return Ok(_mapper.Map<List<FitnessClubVM>>(entitiesDto));
        }
    }
}
