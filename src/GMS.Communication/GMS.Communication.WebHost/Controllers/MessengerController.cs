using GMS.Communication.WebHost.Hubs;
using GMS.Communication.WebHost.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using JWTAuthManager;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace GMS.Communication.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessengerController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public MessengerController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [Authorize]
        [RequirePrivelege(Priviliges.Administrator, Priviliges.System)] //ограничения доступа к ручке
        [Route("SendToAll")]
        [HttpPost]
        public async Task<IActionResult> SendMessageToAll([FromBody]MessageRequestDTO requestMessage)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", requestMessage.Subject, requestMessage.Body);
            return Ok();
        }

        [Authorize] //ограничения доступа к ручке
        [Route("SendById")]
        [HttpPost]
        public async Task<IActionResult> SendById([FromBody]MessageRequestDTO requestMessage)
        {
            await _hubContext.Clients.User(requestMessage.RecipientId.ToString()).SendAsync("ReceiveMessage", requestMessage.Subject, requestMessage.Body);
            return Ok();
        }

        [Authorize] //ограничения доступа к ручке
        [Route("SendByGroup")] // Для спринта №4 - будет применяться для чат комнат.
        [HttpPost]
        public async Task<IActionResult> SendByGroup([FromBody]MessageRequestDTO requestMessage)
        {
            throw new NotImplementedException();
        }
    }
}
