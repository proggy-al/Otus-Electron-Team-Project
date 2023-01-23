using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.WebHost.Models;

public class XUserJwtTokenModel
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string Role { get; set; } = "User";

    public string TelegramUserName { get; set; }
}