using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GMS.Core.WebHost.Controllers.Base
{
    [ApiController]
    public abstract class BaseController<TService> : ControllerBase
        where TService : IService
    {
        protected readonly TService _service;
        protected readonly IMapper _mapper;

        protected BaseController(TService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        protected virtual Guid UserId => Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
        protected virtual string UserRole => User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
        protected virtual string UserName => User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;

        /// <summary>
        /// Получить токен из заголовка запроса;
        /// </summary>
        /// <returns></returns>
        protected virtual string? GetToken()
        {
            return HttpContext.Request.Headers["Authorization"].First();
        }
    }
}

