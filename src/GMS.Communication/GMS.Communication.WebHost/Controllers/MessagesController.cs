using GMS.Communication.WebHost.Hubs;
using GMS.Communication.WebHost.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GMS.Communication.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public MessagesController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [Route("SendMessageToAll")]
        [HttpPost]
        public async Task<IActionResult> SendMessageToAll([FromBody]MessageRequestDTO request)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", request.Subject, request.Body);
            return Ok();
        }

        [Route("SendMessageById")]
        [HttpPost]
        public async Task<IActionResult> SendMessageById([FromBody]MessageRequestDTO request)
        {            
            await _hubContext.Clients.User(request.RecipientId.ToString()).SendAsync("ReceiveMessage", request.Subject, request.Body);
            return Ok();
        }
    }
}
