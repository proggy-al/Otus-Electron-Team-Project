using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.WebHost.Controllers.Base;
using GMS.Core.WebHost.Models;
using JWTAuthManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GMS.Core.WebHost.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : BaseController<IContractService>
    {
        public ContractController(IContractService service, IMapper mapper) : base(service, mapper) { }

        //[Authorize(Roles = nameof(Priviliges.Manager))]
        //[HttpGet("[action]/{pageNumber}:{pageSize}")]
        /*public async Task<IActionResult> GetPagedNotApproved(Guid fitnessClubId, int pageNumber=1, int pageSize=12)
        {
            // все не подтвержденные контракты
            var pagedList = await _service.GetPage(fitnessClubId, pageNumber, pageSize);
            var result = _mapper.Map<List<AreaResponse>>(pagedList.Entities);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedList.Pagination));
            return Ok(result);
        }*/

        //[Authorize(Roles = nameof(Priviliges.Manager))]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPagedApproved(Guid fitnessClubId, int pageNumber = 1, int pageSize = 12)
        {
            // подтвержденные контракты
            throw new NotImplementedException();
        }

        ///[Authorize(Roles = nameof(Priviliges.User))]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPage(int pageNumber = 1, int pageSize = 12)
        {
            // все контракты пользователя
            throw new NotImplementedException();
        }

        //[Authorize(Roles = nameof(Priviliges.GYMOwner))]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPageByFitnessClubId(Guid fitnessClubId, int pageNumber = 1, int pageSize = 12)
        {
            // только подтвержденные контракты
            throw new NotImplementedException();
        }

        //[Authorize(Roles = nameof(Priviliges.User))]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(Guid productId)
        {
            throw new NotImplementedException();
        }

        //[Authorize(Roles = nameof(Priviliges.Manager))]
        [HttpPut("[action]")]
        public async Task<IActionResult> Approve(Guid contractId)
        {
            // ToDo: реализовать подтверждение контракта. Свойство IsApproved и ManagerId
            throw new NotImplementedException();
        }
    }
}
