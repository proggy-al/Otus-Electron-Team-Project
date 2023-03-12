﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.Client
{
    public class IdentityRouting
    {
        public const string GetAllUsers = "user";
        public const string GetUser = "user/{id}";
        public const string CreateUser = "user";
        public const string PatchUser = "user/{id}";
        public const string DeleteUser = "user/{id}";
        public const string GetToken = "authorize";
    }
}
