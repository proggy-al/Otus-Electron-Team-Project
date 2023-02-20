using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions.Base;
using GMS.Core.Core.Abstractions.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Core.WebHost.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TController, TService, T, TDto, TVm, TPrimaryKey> : ControllerBase
        where TController : class
        where TService : IBaseService<IRepository<T, TPrimaryKey>, T, TDto, TPrimaryKey>
        where T : IEntity<TPrimaryKey>
        where TDto : class
    {
        protected readonly TService _service;
        protected readonly ILogger<TController> _logger;
        protected readonly IMapper _mapper;

        protected BaseController(TService service, ILogger<TController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Get(TPrimaryKey id)
        {
            if (id == null || id.Equals(Guid.Empty))
                return BadRequest();

            var entitiesDto = await _service.GetById(id);

            if (entitiesDto == null)
                return NotFound();

            var result = _mapper.Map<TVm>(entitiesDto);

            return Ok(result);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> Add(TVm viewModel)
        {
            if (viewModel == null)
                return BadRequest();

            var entityDto = _mapper.Map<TDto>(viewModel);

            var id = await _service.Create(entityDto);

            if (id == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(id);
        }

        [HttpPut("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public virtual async Task<IActionResult> Edit(TPrimaryKey id, TVm viewModel)
        {
            if (id == null || id.Equals(Guid.Empty) || viewModel == null)
                return BadRequest();

            var entityDto = _mapper.Map<TDto>(viewModel);
            await _service.Update(id, entityDto);

            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public virtual async Task<IActionResult> Delete(TPrimaryKey id)
        {
            if (id == null || id.Equals(Guid.Empty))
                return BadRequest();

            await _service.Delete(id);

            return Ok();
        }
    }
}

