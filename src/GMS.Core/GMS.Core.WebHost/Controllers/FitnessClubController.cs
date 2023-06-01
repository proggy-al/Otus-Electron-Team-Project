using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Controllers.Base;
using GMS.Core.WebHost.Models;
using GMS.Core.WebHost.Models.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GMS.Core.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class FitnessClubController : BaseController<IFitnessClubService>
    {
        public FitnessClubController(IFitnessClubService service, IMapper mapper) : base(service, mapper) { }

        /// <summary>
        /// Получение списка фитнес клубов
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>List<FitnessClubResponse></returns>
        [AllowAnonymous]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPage(int pageNumber = 1, int pageSize = 6)
        {
            var pagedList = await _service.GetPage(pageNumber, pageSize);
            var result = _mapper.Map<List<FitnessClubResponse>>(pagedList.Entities);

            return Ok(new ResponseWrapper<List<FitnessClubResponse>>(result, pagedList.Pagination));
        }

        /// <summary>
        /// Получение списка фитнес клубов владельца
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>List<FitnessClubResponse></returns>
        [Authorize(Policy = "GymOwner")]
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPageByOwnerId(int pageNumber = 1, int pageSize = 6)
        {
            var pagedList = await _service.GetPageByOwnerId(UserId, pageNumber, pageSize);
            var result = _mapper.Map<List<FitnessClubResponse>>(pagedList.Entities);

            return Ok(new ResponseWrapper<List<FitnessClubResponse>>(result, pagedList.Pagination));
        }

        /// <summary>
        /// Получение информации о клубе
        /// </summary>
        /// <param name="id">идентификатор клуба</param>
        /// <returns>FitnessClubResponse</returns>
        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var fitnessClubDto = await _service.Get(id);
            var result = _mapper.Map<FitnessClubResponse>(fitnessClubDto);

            return Ok(result);
        }

        /// <summary>
        /// Добавить фитнес клуб
        /// </summary>
        /// <param name="request">информация о клубе</param>
        /// <returns>идентификатор клуба</returns>
        [Authorize(Policy = "GymOwner")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(FitnessClubCreateOrEditRequest request)
        {
            var fitnessClubDto = _mapper.Map<FitnessClubCreateDto>(request);
            fitnessClubDto.OwnerId = UserId;

            var id = await _service.Create(fitnessClubDto);

            return Ok(id.ToString());
        }
        /// <summary>
        /// Отредактировать информацию фитнес клуба
        /// </summary>
        /// <param name="id">идендификатор клуба</param>
        /// <param name="request">информация о клубе</param>
        /// <returns></returns>
        [Authorize(Policy = "Administrator")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Edit(Guid id, FitnessClubCreateOrEditRequest request)
        {
            var fitnessClubDto = _mapper.Map<FitnessClubEditDto>(request);
            fitnessClubDto.UserId = UserId;

            await _service.Update(id, fitnessClubDto);

            return NoContent();
        }

        /// <summary>
        /// Поместить клуб в архив
        /// </summary>
        /// <param name="id">идентификатор клуба</param>
        /// <returns></returns>
        [Authorize(Policy = "GymOwner")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> AddToArchive(Guid id)
        {
            await _service.AddToArchive(id, UserId);

            return NoContent();
        }
    }
}
