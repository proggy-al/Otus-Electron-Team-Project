using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Controllers.Base;
using GMS.Core.WebHost.HttpClients.Abstractions;
using GMS.Core.WebHost.Models;
using GMS.Core.WebHost.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GMS.Core.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<IEmployeeService>
    {
        private IUserHttpClient _userHttpClient;
        private ICoachHttpClient _coachHttpClient;

        public EmployeeController(IEmployeeService service, IMapper mapper, IUserHttpClient httpClient, ICoachHttpClient coachHttpClient) : base(service, mapper) 
        {
            _userHttpClient = httpClient;
            _coachHttpClient = coachHttpClient;
        }

        [Authorize(Policy = "Administrator")]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPage(Guid fitnessClubId, int pageNumber = 1, int pageSize = 12)
        {
            var pagedList = await _service.GetPage(UserId, fitnessClubId, pageNumber, pageSize);

            _userHttpClient.Token = GetToken();
            var userApiModel = await _userHttpClient.GetUsersAsync(pagedList.Entities);

            var result = _mapper.Map<List<EmployeeResponse>>(userApiModel);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedList.Pagination));
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPageTrainers(Guid fitnessClubId, int pageNumber = 1, int pageSize = 12)
        {
            var pagedList = await _service.GetPagedTrainers(fitnessClubId, pageNumber, pageSize);

            _coachHttpClient.Token = GetToken();
            var coaches = await _coachHttpClient.GetPagedCoachesAsync(pagedList.Entities);

            var result = _mapper.Map<List<TrainerResponse>>(coaches);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedList.Pagination));
            return Ok(result);
        }

        [Authorize(Policy = "Administrator")]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPageManagers(Guid fitnessClubId, int pageNumber = 1, int pageSize = 12)
        {
            var pagedList = await _service.GetPagedManagers(UserId,fitnessClubId, pageNumber, pageSize);

            _userHttpClient.Token = GetToken();
            var managers = await _userHttpClient.GetUsersAsync(pagedList.Entities);

            var result = _mapper.Map<List<EmployeeResponse>>(managers);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedList.Pagination));
            return Ok(result);
        }

        [Authorize(Policy = "Administrator")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            await _service.Get(id, UserId);

            _userHttpClient.Token = GetToken();
            var userApiModel = await _userHttpClient.GetUserAsync(id);

            var result = _mapper.Map<EmployeeResponse>(userApiModel);

            return Ok(result);
        }

        [Authorize(Policy = "Administrator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(EmployeeCreateRequest request)
        {
            var userModel = _mapper.Map<UserCreateApiModel>(request);

            _userHttpClient.Token = GetToken();
            var createdUserId = await _userHttpClient.CreateUserAsync(userModel);

            await _service.Create(new EmployeeCreateOrEditDto
            {
                Id = createdUserId,
                FitnessClubId = request.FitnessClubId,
                UserId = UserId,
                Role = request.Role
            });

            return Ok(createdUserId);
        }

        [Authorize(Policy = "Administrator")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> AddToArchive(Guid id)
        {
            await _service.AddToArchive(id, UserId);

            return NoContent();
        }
    }
}
