using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.Client
{
    public class IdentityRouting
    {
        public const string GetAllUsers = "user";
        public const string GetListUsers = "user/ids";
        public const string GetListShortInfoUsers = "user/info/ids";
        public const string GetUser = "user/{id}";
        public const string CreateUser = "user";
        public const string PatchUser = "user/{id}";
        public const string DeleteUser = "user/{id}";
        public const string GetToken = "authorize";
        public const string GetAllCoaches = "coach";
        public const string GetListCoaches = "coach/ids";
        public const string GetCoach = "coach/{id}";
    }
}
