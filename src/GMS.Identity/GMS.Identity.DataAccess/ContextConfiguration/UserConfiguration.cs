using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMS.Identity.Core.Domain.Administration;
using GMS.Identity.DataAccess.Utils;

namespace GMS.Identity.DataAccess.ContextConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(200);

            var testPas1 = UserHelper.GetSaltAndPassword("123456");
            var testPas2 = UserHelper.GetSaltAndPassword("123456");

            // Для примера, позже удалить
            builder.HasData(
                new User() { Id = Guid.NewGuid(), UserName = "Sash", TelegramUserName = "@sash", Salt = testPas1.salt, PasswordHash = testPas1.pass, Role = "Administrator", Email = "sash@mail.ru", IsActive = true },
                new User() { Id = Guid.NewGuid(), UserName = "Dan", TelegramUserName = "@dan", Salt = testPas2.salt, PasswordHash = testPas2.pass, Role = "Administrator", Email = "dan@mail.ru", IsActive = true },
                new User() { Id = Guid.NewGuid(), UserName = "System", TelegramUserName = "@system", Salt = testPas2.salt, PasswordHash = testPas2.pass, Role = "System", Email = "sys@mail.ru", IsActive = true },
                new User() { Id = Guid.NewGuid(), UserName = "User", TelegramUserName = "@user", Salt = testPas2.salt, PasswordHash = testPas2.pass, Role = "User", Email = "user@mail.ru", IsActive = true }
            );
        }
    }
}
