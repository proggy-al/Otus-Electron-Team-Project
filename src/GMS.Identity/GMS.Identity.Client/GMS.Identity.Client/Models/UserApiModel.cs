using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.Client.Models;

public class UserApiModel
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string TelegramUserName { get; set; }

    public string Email { get; set; }

    public bool IsActive { get; set; }

    public string Role { get; set; }

}
