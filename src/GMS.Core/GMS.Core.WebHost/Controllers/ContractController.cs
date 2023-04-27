using AutoMapper;
using GMS.Common;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.WebHost.Controllers.Base;
using GMS.Core.WebHost.HttpClients.Abstractions;
using GMS.Core.WebHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GMS.Core.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : BaseController<IContractService>
    {
        private IUserHttpClient _httpClient;

        public ContractController(IContractService service, IMapper mapper, IUserHttpClient httpClient) : base(service, mapper)
        {
            _httpClient = httpClient;
        }

        [Authorize(Policy = "Manager")]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPageNotApproved(Guid fitnessClubId, int pageNumber = 1, int pageSize = 12)
        {
            // получаем список неподтвержденных контрактов
            var pagedContracts = await _service.GetPageNotApproved(UserId, fitnessClubId, pageNumber, pageSize);

            if (pagedContracts.Entities.Count == 0)
                return NoContent();

            // получаем список уникальных Id пользователей в контрактах(т.к. пользователи могут повторяться)
            var uniqUserIds = pagedContracts.Entities.Select(x => x.UserId).Distinct().ToList();

            // запрашиваем информацию о пользователях в Identity microservice
            _httpClient.Token = GetToken();
            var users = await _httpClient.GetUsersAsync(uniqUserIds);

            // соединяем информацию контрактов с информацией о пользователях
            var contracts = from u in users
                            join c in pagedContracts.Entities on u.Id equals c.UserId
                            select new ContractNotApprovedResponse
                            {
                                Id = c.Id,
                                User = new UserResponse
                                {
                                    Id = u.Id,
                                    Name = u.UserName,
                                    Email = u.Email,
                                    TelegramName = u.TelegramUserName
                                },
                                Product = new ProductResponse
                                {
                                    Id = c.Product.Id,
                                    Name = c.Product.Name,
                                    Description = c.Product.Description,
                                    Quantity = c.Product.Quantity,
                                    Price = c.Product.Price
                                },
                                StartDate = c.StartDate,
                                EndDate = c.EndDate
                            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedContracts.Pagination));
            return Ok(contracts);
        }

        [Authorize(Policy = "Manager")]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPage(Guid fitnessClubId, int pageNumber = 1, int pageSize = 12)
        {
            // получаем список контрактов
            var pagedContracts = await _service.GetPageApproved(UserId, fitnessClubId, pageNumber, pageSize);

            if (pagedContracts.Entities.Count == 0)
                return NoContent();

            // получаем список уникальных Id пользователей и сотрудников в контрактах
            var uniqUserIds = pagedContracts.Entities.Select(x => x.UserId).Distinct().ToList();
            var uniqManagerIds = pagedContracts.Entities.Select(x => x.ManagerId).Distinct().ToList();

            // запрашиваем информацию о пользователях b сотрудниках в Identity microservice
            _httpClient.Token = GetToken();
            var users = await _httpClient.GetUsersAsync(uniqUserIds);
            var managers = await _httpClient.GetUsersAsync(uniqManagerIds);

            // соединяем информацию контрактов с информацией о пользователях
            var contracts = from c in pagedContracts.Entities
                            join u in users on c.UserId equals u.Id
                            join m in managers on c.ManagerId equals m.Id
                            select new ContractResponse
                            {
                                Id = c.Id,
                                User = new UserResponse
                                {
                                    Id = u.Id,
                                    Name = u.UserName,
                                    Email = u.Email,
                                    TelegramName = u.TelegramUserName
                                },
                                Manager = new ManagerResponse
                                {
                                    Id = m.Id,
                                    Name = m.UserName
                                },
                                Product = new ProductResponse
                                {
                                    Id = c.Product.Id,
                                    Name = c.Product.Name,
                                    Description = c.Product.Description,
                                    Quantity = c.Product.Quantity,
                                    Price = c.Product.Price
                                },
                                StartDate = c.StartDate,
                                EndDate = c.EndDate
                            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedContracts.Pagination));
            return Ok(contracts);
        }

         
         [Authorize(Roles = nameof(Priviliges.User))]
         [HttpGet("[action]/{pageNumber}:{pageSize}")]
         public async Task<IActionResult> GetPageByUser(int pageNumber = 1, int pageSize = 12)
         {
            var pagedContracts = await _service.GetPageByUserId(UserId, pageNumber, pageSize);

            if (pagedContracts.Entities.Count == 0)
                return NoContent();

           var contracts = _mapper.Map<List<ContractUserResponse>>(pagedContracts.Entities);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedContracts.Pagination));
            return Ok(contracts);
        }

         [Authorize(Roles = nameof(Priviliges.User))]
         [HttpPost("[action]")]
         public async Task<IActionResult> Add(Guid productId)
         {
            var id = await _service.Create(productId, UserId);
            return Ok(id.ToString());
         }

         [Authorize(Roles = nameof(Priviliges.Manager))]
         [HttpPut("[action]")]
         public async Task<IActionResult> Approve(Guid contractId)
         {
            await _service.Approve(contractId, UserId);
            return NoContent();
        }
    }
}
