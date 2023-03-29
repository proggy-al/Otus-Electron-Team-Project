using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.WebHost.Controllers.Base;
using GMS.Core.WebHost.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Core.WebHost.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : BaseController<IContractService>
    {
        public ContractController(IContractService service, IMapper mapper) : base(service, mapper) { }

        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPagedByManagerId(Guid managerId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPageByUserId(Guid userId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPageByFitnessClubId(Guid fitnessClubId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(ContractCreateRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Approve(ContractApproveRequest request)
        {
            // ToDo: реализовать подтверждение контракта. Свойство IsApproved и ManagerId
            throw new NotImplementedException();
        }
    }
}
