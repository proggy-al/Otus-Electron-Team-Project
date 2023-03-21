using Microsoft.AspNetCore.SignalR;

namespace GMS.Communication.WebHost.Models
{
    public class MyUserProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            var x = connection.User.Claims.FirstOrDefault(x => x.Type == "ID");
            return "c35e71b1-01fe-4e96-aa13-35371f792a4f";
        }
    }
}
