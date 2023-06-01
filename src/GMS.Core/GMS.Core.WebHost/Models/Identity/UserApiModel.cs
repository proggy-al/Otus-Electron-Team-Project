namespace GMS.Core.WebHost.Models.Identity
{
    public class UserApiModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string TelegramUserName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string Role { get; set; }
    }
}
