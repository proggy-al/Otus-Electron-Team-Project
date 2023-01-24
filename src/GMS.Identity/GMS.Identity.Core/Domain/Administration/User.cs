using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.Core.Domain.Administration
{
    public class User : BaseEntity, IEquatable<Guid>, IEquatable<User>
    {
        public string UserName { get; set; }

        //Закоментированные далее поля - потенциально в будущем поля сущности пользователь

        //public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        //public string NormalizedEmail { get; set; }

        //public bool EmailConfirmed { get; set; }

        //public string PhoneNumber { get; set; }

        //public bool PhoneNumberConfirmed { get; set; }

        public string TelegramUserName { get; set; }

        //public bool TelegramUserNameConfirmed { get; set; }

        public string Salt { get; set; }

        public string PasswordHash { get; set; }

        //public string ConcurrencyStamp { get; set; }

        //public virtual string SecurityStamp { get; set; }

        //public virtual DateTimeOffset? LockoutEnd { get; set; }

        //public bool TwoFactorEnabled { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// Сравнение по GUID
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Guid other)
        {
            return this.Id == other;
        }

        /// <summary>
        /// Сравнение двух User
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(User other)
        {
            return this.UserName == other.UserName;
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.UserName} - {this.TelegramUserName}";
        }
    }
}
