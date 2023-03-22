using Microsoft.AspNetCore.SignalR;
using System.Security.Principal;

namespace GMS.Communication.WebHost.Hubs
{

    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {        
            var id= Context.User?.Claims.FirstOrDefault(a => a.Type == "ID")?.Value;
            if (id is null) throw new IdentityNotMappedException(nameof(OnConnectedAsync));
            await base.OnConnectedAsync();
        }
    }
}
