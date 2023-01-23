using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.WebHost.Models;
    public class XUserApiModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string TelegramUserName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }  

    }

