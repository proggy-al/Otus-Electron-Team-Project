using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMS.Identity.Core.Domain.Administration;
using GMS.Identity.DataAccess.Utils;
using JWTAuthManager;

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
                  new User() { Id = new Guid("a24ab827-10a5-47bf-86bd-39adeb89b6c9"), UserName = "Sash", TelegramUserName = "@sash", Salt = testPas1.salt, PasswordHash = testPas1.pass, Role = "Administrator", Email = "sash@mail.ru", IsActive = true },
                  new User() { Id = new Guid("8699aba2-5ec1-40cf-b186-36ca13c15ea2"), UserName = "Dan", TelegramUserName = "@dan", Salt = testPas2.salt, PasswordHash = testPas2.pass, Role = "Administrator", Email = "dan@mail.ru", IsActive = true },
                  new User() { Id = new Guid("c35e71b1-01fe-4e96-aa13-35371f792a4f"), UserName = "System", TelegramUserName = "@system", Salt = testPas2.salt, PasswordHash = testPas2.pass, Role = "System", Email = "sys@mail.ru", IsActive = true },
                  new User() { Id = new Guid("6f35e9ac-2718-4b98-9a39-d3c136217e97"), UserName = "User", TelegramUserName = "@user", Salt = testPas2.salt, PasswordHash = testPas2.pass, Role = "User", Email = "user@mail.ru", IsActive = true },


                  // Владельцы
                  new User()
                  {
                      Id = new Guid("00000000-0000-0000-0004-000000000001"),
                      Email = "joegold@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "GYMOwner",
                      Salt = testPas1.salt,
                      TelegramUserName = "@joegold",
                      UserName = "Joe"
                  },
                  new User()
                  {
                      Id = new Guid("00000000-0000-0000-0004-000000000002"),
                      Email = "andrey@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "GYMOwner",
                      Salt = testPas1.salt,
                      TelegramUserName = "@andrey",
                      UserName = "Андрей"
                  },
                  new User()
                  {
                      Id = new Guid("00000000-0000-0000-0004-000000000003"),
                      Email = "gymowner3@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "GYMOwner",
                      Salt = testPas1.salt,
                      TelegramUserName = "@gymowner3",
                      UserName = "Owner3"
                  },

                  // Администраторы
                  new User()
                  {
                      Id = new Guid("10000000-0000-0000-0001-000000000001"),
                      Email = "goldgymadministrator@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "Administrator",
                      Salt = testPas1.salt,
                      TelegramUserName = "@goldgymadministrator",
                      UserName = "GoldGymAdministrator"
                  },
                  new User()
                  {
                      Id = new Guid("10000000-0000-0000-0001-000000000002"),
                      Email = "almazadministrator@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "Administrator",
                      Salt = testPas1.salt,
                      TelegramUserName = "@almazadministrator",
                      UserName = "AlmazAdministrator"
                  },
                  new User()
                  {
                      Id = new Guid("10000000-0000-0000-0001-000000000003"),
                      Email = "administrator3@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "Administrator",
                      Salt = testPas1.salt,
                      TelegramUserName = "@administrator3",
                      UserName = "Administrator3"
                  },

                  // Менеджеры
                  new User()
                  {
                      Id = new Guid("10000000-0000-0000-0006-000000000001"),
                      Email = "goldgymmanager@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "Manager",
                      Salt = testPas1.salt,
                      TelegramUserName = "@goldgymmanager",
                      UserName = "GoldGymManager"
                  },
                  new User()
                  {
                      Id = new Guid("10000000-0000-0000-0006-000000000002"),
                      Email = "almazmanager@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "Manager",
                      Salt = testPas1.salt,
                      TelegramUserName = "@almazmanager",
                      UserName = "AlmazManager"
                  },
                  new User()
                  {
                      Id = new Guid("10000000-0000-0000-0006-000000000003"),
                      Email = "manager3@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "Manager",
                      Salt = testPas1.salt,
                      TelegramUserName = "@manager3",
                      UserName = "Manager3"
                  },

                  // Пользователи
                  new User()
                  {
                      Id = new Guid("00000000-0000-0000-0002-000000000001"),
                      Email = "johngold@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "User",
                      Salt = testPas1.salt,
                      TelegramUserName = "@johngold",
                      UserName = "John"
                  },
                  new User()
                  {
                      Id = new Guid("00000000-0000-0000-0002-000000000002"),
                      Email = "ivanalmaz@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "User",
                      Salt = testPas1.salt,
                      TelegramUserName = "@ivanalmaz",
                      UserName = "Иван"
                  },
                  new User()
                  {
                      Id = new Guid("00000000-0000-0000-0002-000000000003"),
                      Email = "user3@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "User",
                      Salt = testPas1.salt,
                      TelegramUserName = "@user3",
                      UserName = "User3"
                  },

                  // Тренера
                  new User()
                  {
                      Id = new Guid("10000000-0000-0000-0005-000000000001"),
                      Email = "arnoldgold@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "Coach",
                      Salt = testPas1.salt,
                      TelegramUserName = "@arnoldgold",
                      UserName = "Arnold"
                  },
                  new User()
                  {
                      Id = new Guid("10000000-0000-0000-0005-000000000002"),
                      Email = "alekseialmaz@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "Coach",
                      Salt = testPas1.salt,
                      TelegramUserName = "@alekseialmaz",
                      UserName = "Алексей"
                  },
                  new User()
                  {
                      Id = new Guid("10000000-0000-0000-0005-000000000003"),
                      Email = "trainer3@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "Coach",
                      Salt = testPas1.salt,
                      TelegramUserName = "@trainer3",
                      UserName = "Trainer3"
                  },
                  new User()
                  {
                      Id = new Guid("10000000-0000-0000-0005-000000000004"),
                      Email = "trainer4@mail.ru",
                      IsActive = true,
                      PasswordHash = testPas1.pass,
                      Role = "Coach",
                      Salt = testPas1.salt,
                      TelegramUserName = "@trainer4",
                      UserName = "Trainer4"
                  }
            );
        }
    }
}

