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

        [Route("Send")]
        [HttpPost]
        public IActionResult SendMessage([FromBody]MessageRequestDTO request)
        {
            _hubContext.Clients.All.SendAsync("ReceiveMessage", request.message, request.userId);
            return Ok();
        }
    }
}
