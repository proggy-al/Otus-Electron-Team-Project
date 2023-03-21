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
    public class MessagesController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public MessagesController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        //[RequirePrivelege(Priviliges.Administrator, Priviliges.System)] //ограничения доступа к ручке
        [Route("SendMessageToAll")]
        [HttpPost]
        public async Task<IActionResult> SendMessageToAll([FromBody]MessageRequestDTO request)
        {
            //так мы получаем ID авторизованного юзера
            var id= User.Claims.FirstOrDefault(a => a.Type == "ID").Value;


            await _hubContext.Clients.All.SendAsync("ReceiveMessage", request.Subject, request.Body);
            return Ok();
        }

        //[Authorize] //ограничения доступа к ручке
        //[RequirePrivelege(Priviliges.Administrator, Priviliges.System)] //ограничения доступа к ручке
        [Route("SendMessageById")]
        [HttpPost]
        public async Task<IActionResult> SendMessageById(string clientId)
        {
            //так мы получаем ID авторизованного юзера
            
            //await _hubContext.Clients.User(request.RecipientId.ToString()).SendAsync("ReceiveMessage", request.Subject, request.Body);
            await _hubContext.Clients.User("c35e71b1-01fe-4e96-aa13-35371f792a4f").SendAsync("ReceiveMessage", "Test", $"Hooray, id:c35e71b1-01fe-4e96-aa13-35371f792a4f");
            //await _hubContext.Clients.User("System").SendAsync("ReceiveMessage", "Test", $"Hooray, id:c35e71b1-01fe-4e96-aa13-35371f792a4f");
            //await _hubContext.Clients.Client(clientId).SendAsync("ReceiveMessage", "Test", $"Hooray, id:c35e71b1-01fe-4e96-aa13-35371f792a4f");
            return Ok();
        }
    }
}
