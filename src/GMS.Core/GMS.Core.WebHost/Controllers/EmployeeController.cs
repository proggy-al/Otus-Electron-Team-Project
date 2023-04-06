using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Controllers.Base;
using GMS.Core.WebHost.HttpClients;
using GMS.Core.WebHost.Models;
using GMS.Core.WebHost.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GMS.Core.WebHost.Controllers
{
    [Authorize(Policy = "GymOwner")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<IEmployeeService>
    {
        private IUserHttpClient _httpClient;
        public EmployeeController(IEmployeeService service, IMapper mapper, IUserHttpClient httpClient) : base(service, mapper) 
        {
            _httpClient = httpClient;
        }

        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPage(Guid fitnessClubId, int pageNumber = 1, int pageSize = 12)
        {
            var pagedList = await _service.GetPage(UserId, fitnessClubId, pageNumber, pageSize);

            _httpClient.Token = GetToken();
            var userApiModel = await _httpClient.GetPagedUsersAsync(pagedList.Entities);

            var result = _mapper.Map<List<EmployeeResponse>>(userApiModel);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedList.Pagination));
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            await _service.Get(id, UserId);

            _httpClient.Token = GetToken();
            var userApiModel = await _httpClient.GetUserAsync(id);

            var result = _mapper.Map<EmployeeResponse>(userApiModel);

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(EmployeeCreateRequest request)
        {
            var userModel = _mapper.Map<UserCreateApiModel>(request);

            _httpClient.Token = GetToken();
            var createdUserId = await _httpClient.CreateUserAsync(userModel);

            await _service.Create(new EmployeeCreateOrEditDto
            {
                Id = createdUserId,
                FitnessClubId = request.FitnessClubId,
                OwnerId = UserId
            });

            return Ok(createdUserId);
        }

        /*[HttpPut("[action]/{id}")]
        public async Task<IActionResult> Edit(Guid id, AreaEditRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> AddToArchive(Guid id)
        {
            throw new NotImplementedException();
        }*/
    }
}
