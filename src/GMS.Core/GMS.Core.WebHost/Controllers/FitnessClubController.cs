using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Controllers.Base;
using GMS.Core.WebHost.Models;
using JWTAuthManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace GMS.Core.WebHost.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessClubController : BaseController<IFitnessClubService>
    {
        public FitnessClubController(IFitnessClubService service, ILogger<FitnessClubController> logger, IMapper mapper) 
            : base(service, logger, mapper) { }

        /// <summary>
        /// Получение списка фитнес клубов
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>List<FitnessClubResponse></returns>
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPage(int pageNumber = 1, int pageSize = 6)
        {
            var pagedList = await _service.GetPage(pageNumber, pageSize);
            var result = _mapper.Map<List<FitnessClubResponse>>(pagedList.Entities);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedList.Pagination));
            
            int cnt = result.Count();
            _logger.LogInformation($"Returned {cnt} FitnessClub{(cnt > 1 ? "s" : "")} from database.");

            return Ok(result);
        }

        /// <summary>
        /// Получение списка фитнес клубов пользователя
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>List<FitnessClubResponse></returns>
        //[Authorize(Roles = nameof(Priviliges.GYMOwner))]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPageByOwnerId(int pageNumber = 1, int pageSize = 6)
        {
            var pagedList = await _service.GetPageByOwnerId(UserId, pageNumber, pageSize);
            var result = _mapper.Map<List<FitnessClubResponse>>(pagedList.Entities);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedList.Pagination));
            
            int cnt = result.Count();
            _logger.LogInformation($"Returned {cnt} FitnessClub{(cnt > 1 ? "s" : "")} from database.");

            return Ok(result);
        }

        /// <summary>
        /// Получение информации о клубе
        /// </summary>
        /// <param name="id">идентификатор клуба</param>
        /// <returns>FitnessClubResponse</returns>
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var fitnessClubDto = await _service.Get(id);
            var result = _mapper.Map<FitnessClubResponse>(fitnessClubDto);

            _logger.LogInformation($"Returned FitnessClub \"{id}\" from database.");

            return Ok(result);
        }

        /// <summary>
        /// Добавить фитнес клуб
        /// </summary>
        /// <param name="request">информация о клубе</param>
        /// <returns>идентификатор клуба</returns>
        //[Authorize(Roles = nameof(Priviliges.GYMOwner))]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(FitnessClubCreateOrEditRequest request)
        {
            var fitnessClubDto = _mapper.Map<FitnessClubCreateOrEditDto>(request);
            fitnessClubDto.OwnerId = UserId;

            var id = await _service.Create(fitnessClubDto);

            _logger.LogInformation($"Add FitnessClub \"{id}\" to database.");

            return Ok(id.ToString());
        }
        /// <summary>
        /// Отредактировать информацию фитнес клуба
        /// </summary>
        /// <param name="id">идендификатор клуба</param>
        /// <param name="request">информация о клубе</param>
        /// <returns></returns>
        //[Authorize(Roles = nameof(Priviliges.GYMOwner))]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Edit(Guid id, FitnessClubCreateOrEditRequest request)
        {
            var fitnessClubDto = _mapper.Map<FitnessClubCreateOrEditDto>(request);
            fitnessClubDto.OwnerId = UserId;

            await _service.Update(id, fitnessClubDto);

            _logger.LogInformation($"Edit FitnessClub \"{id}\" in database");

            return NoContent();
        }

        /// <summary>
        /// Поместить клуб в архив
        /// </summary>
        /// <param name="id">идентификатор клуба</param>
        /// <returns></returns>
        //[Authorize(Roles = nameof(Priviliges.GYMOwner))]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> AddToArchive(Guid id)
        {
            await _service.AddToArchive(id, UserId);

            _logger.LogInformation($"Add to archive FitnessClub \"{id}\"");

            return NoContent();
        }
    }
}
