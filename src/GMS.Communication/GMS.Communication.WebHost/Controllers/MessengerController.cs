using AutoMapper;
using GMS.Communication.Core.Abstractons;
using GMS.Communication.Core.Domain;
using GMS.Communication.WebHost.Hubs;
using GMS.Communication.WebHost.Models;
using JWTAuthManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GMS.Communication.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessengerController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IRepository<GmsMessage> _db;
        private readonly IMapper _mapper;

        public MessengerController(IHubContext<ChatHub> hubContext, IRepository<GmsMessage> db, IMapper mapper)
        {
            _hubContext = hubContext;
            _db = db;
            _mapper = mapper;
        }

        [Authorize]
        [RequirePrivelege(Priviliges.Administrator, Priviliges.System)]
        [Route("SendToAll")]
        [HttpPost]
        public async Task<IActionResult> SendMessageToAll([FromBody]MessageRequestDTO requestMessage)
        {
            var message = _mapper.Map<GmsMessage>(requestMessage);
            await _db.CreateAsync(message);
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", requestMessage.Subject, requestMessage.Body);
            return Ok();
        }

        [Authorize]
        [Route("SendById")]
        [HttpPost]
        public async Task<IActionResult> SendById([FromBody]MessageRequestDTO requestMessage)
        {
            var message = _mapper.Map<GmsMessage>(requestMessage);
            await _db.CreateAsync(message);
            await _hubContext.Clients.User(requestMessage.RecipientId.ToString()).SendAsync("ReceiveMessage", requestMessage.Subject, requestMessage.Body);
            return Ok();
        }

        [Authorize]
        [Route("GetUsersMessagesByUserId")]
        [HttpPost]
        public async Task<IEnumerable<GmsMessage>> GetUsersMessagesByUserId(Guid userId)
        {
            var messages = await _db.GetByPredicateAsync(x => x.SenderId == userId || x.RecipientId == userId);
            return messages;
        }

        [Authorize]
        [RequirePrivelege(Priviliges.Administrator, Priviliges.System)]
        [Route("SendByGroup")]
        [HttpPost]
        public async Task<IActionResult> SendByGroup([FromBody]MessageRequestDTO requestMessage)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [Route("AddToGroup")]
        [HttpPost]
        public async Task<IActionResult> AddToGroup([FromBody]MessageRequestDTO requestMessage)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [Route("RemoveFromGroup")]
        [HttpPost]
        public async Task<IActionResult> RemoveFromGroup([FromBody]MessageRequestDTO requestMessage)
        {
            throw new NotImplementedException();
        }

    }
}
