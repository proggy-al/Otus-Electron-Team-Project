using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using JWTAuthManager;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Core.WebHost.Controllers.Base
{
    [ApiController]
    public abstract class BaseController<TService> : ControllerBase 
        where TService : IService
    {
        protected readonly TService _service;
        protected readonly ILogger _logger;
        protected readonly IMapper _mapper;

        protected BaseController(TService service, ILogger logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        //protected virtual Guid UserId => Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
        //protected virtual string UserRole => User.Claims.FirstOrDefault(c => c.Type == "Role").Value;



        // Проверка роли пользователя
        //protected virtual Guid UserId => Guid.Parse("00000000-0000-0000-0002-000000000003");
        //protected virtual string UserRole => nameof(Priviliges.User);
        
        // Проверка роли Владельца клуба
        protected virtual Guid UserId => Guid.Parse("00000000-0000-0000-0004-000000000003");
        protected virtual string UserRole => nameof(Priviliges.GYMOwner);

    }
}

