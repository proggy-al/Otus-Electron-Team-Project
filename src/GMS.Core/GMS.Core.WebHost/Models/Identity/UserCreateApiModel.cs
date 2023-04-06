namespace GMS.Core.WebHost.Models.Identity
{
    public class UserCreateApiModel
    {
        public string UserName { get; set; }

        public string TelegramUserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

    }
}
