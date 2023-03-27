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
    [Route("contracts")]
    [ApiController]
    public class ContractController :
        BaseController<ContractController, IContractService, Contract, ContractDto, ContractVM, Guid>
    {
        public ContractController(IContractService service, ILogger<ContractController> logger, IMapper mapper) 
            : base(service, logger, mapper) { }

        /// <summary>
        /// Получение контрактов с пагинацией
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

            return Ok(_mapper.Map<List<ContractVM>>(entitiesDto));
        }

        /// <summary>
        /// Получение оформленных контрактов менеджера
        /// </summary>
        /// <param name="managerId">Идентификатор менеджера</param>
        /// <param name="limit">Количество сущностей</param>
        /// <param name="offset">Индекс начала выборки</param>
        /// <returns></returns>
        [HttpGet("{managerId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPagedByManagerId(Guid managerId, int? limit, int? offset)
        {
            limit = limit ?? int.MaxValue;
            offset = offset ?? 0;

            var entitiesDto = await _service.GetPageByManagerId(managerId, limit.Value, offset.Value);

            if (entitiesDto == null)
                return NotFound();

            return Ok(_mapper.Map<List<ContractVM>>(entitiesDto));
        }

        /// <summary>
        /// Получение контрактов пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="limit">Количество сущностей</param>
        /// <param name="offset">Индекс начала выборки</param>
        /// <returns></returns>
        [HttpGet("{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPageByUserId(Guid userId, int? limit, int? offset)
        {
            limit = limit ?? int.MaxValue;
            offset = offset ?? 0;

            var entitiesDto = await _service.GetPageByUserId(userId, limit.Value, offset.Value);

            if (entitiesDto == null)
                return NotFound();

            return Ok(_mapper.Map<List<ContractVM>>(entitiesDto));
        }
    }
}
