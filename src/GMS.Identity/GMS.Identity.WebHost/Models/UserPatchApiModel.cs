﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.WebHost.Models;

public class XUserPatchApiModel
{
    public string UserName { get; set; }

    public string TelegramUserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Role { get; set; }

    public bool IsActive { get; set; }  


}
