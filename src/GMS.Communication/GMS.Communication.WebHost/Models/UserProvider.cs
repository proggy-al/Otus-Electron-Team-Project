using Microsoft.AspNetCore.SignalR;

namespace GMS.Communication.WebHost.Models
{
    public class MyUserProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            var id = connection.User.Claims.FirstOrDefault(x => x.Type == "ID");
            return id?.ToString();
        }
    }
}
