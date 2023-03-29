using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
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
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<IProductService>
    {
        public ProductController(IProductService service, IMapper mapper) : base(service, mapper) { }

        /// <summary>
        /// Получить список продуктов клуба
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>List<ProductResponse></returns>
        [HttpGet("[action]/{pageNumber}:{pageSize}")]
        public async Task<IActionResult> GetPage(Guid fitnessClubId, int pageNumber = 1, int pageSize = 12)
        {
            var pagedList = await _service.GetPage(fitnessClubId, pageNumber, pageSize);
            var result = _mapper.Map<List<ProductResponse>>(pagedList.Entities);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedList.Pagination));

            return Ok(result);
        }

        /// <summary>
        /// Получение информации о продукте
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var productDto = await _service.Get(id);
            var result = _mapper.Map<ProductResponse>(productDto);

            return Ok(result);
        }

        /// <summary>
        /// Добавить продукт
        /// </summary>
        /// <param name="request">информация о продукте</param>
        /// <returns>идентификатор продукта</returns>
        //[Authorize(Roles = nameof(Priviliges.GYMOwner))]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(ProductCreateRequest request)
        {
            var productDto = _mapper.Map<ProductCreateDto>(request);
            productDto.EmploeeId = UserId;

            var id = await _service.Create(productDto);

            return Ok(id.ToString());
        }

        /// <summary>
        /// Поместить продукт в архив
        /// </summary>
        /// <param name="id">идентификатор продукта</param>
        /// <returns></returns>
        //[Authorize(Roles = nameof(Priviliges.GYMOwner))]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> AddToArchive(Guid id)
        {
            await _service.AddToArchive(id, UserId);

            return NoContent();
        }
    }
}
