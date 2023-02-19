using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace GMS.Communication.WebHost.Hubs
{
    public class ChatHub : Hub
    {
        //[Authorize]
        public async Task SendMessage(string message, Guid userId)
        {
            //await Clients.User(userId).SendAsync("Receive", message, userName);
            await Clients.All.SendAsync("ReceiveMessage", userId, message);
        }
    }
}
