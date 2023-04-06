using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GMS.Identity.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTestUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6f35e9ac-2718-4b98-9a39-d3c136217e97"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "v9UvAOCyNVfzz1lIAX/jUgGI2sCKAuW/HGr3DGngu58=", "LpqopcBCi+JGLZooN8fg2Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8699aba2-5ec1-40cf-b186-36ca13c15ea2"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "v9UvAOCyNVfzz1lIAX/jUgGI2sCKAuW/HGr3DGngu58=", "LpqopcBCi+JGLZooN8fg2Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a24ab827-10a5-47bf-86bd-39adeb89b6c9"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "h7TRguSGJKGsTDKLzqYJ1Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c35e71b1-01fe-4e96-aa13-35371f792a4f"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "v9UvAOCyNVfzz1lIAX/jUgGI2sCKAuW/HGr3DGngu58=", "LpqopcBCi+JGLZooN8fg2Q==" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsActive", "PasswordHash", "Role", "Salt", "TelegramUserName", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0002-000000000001"), "johngold@mail.ru", true, "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "User", "h7TRguSGJKGsTDKLzqYJ1Q==", "@johngold", "John" },
                    { new Guid("00000000-0000-0000-0002-000000000002"), "ivanalmaz@mail.ru", true, "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "User", "h7TRguSGJKGsTDKLzqYJ1Q==", "@ivanalmaz", "Иван" },
                    { new Guid("00000000-0000-0000-0002-000000000003"), "user3@mail.ru", true, "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "User", "h7TRguSGJKGsTDKLzqYJ1Q==", "@user3", "User3" },
                    { new Guid("00000000-0000-0000-0004-000000000001"), "joegold@mail.ru", true, "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "GYMOwner", "h7TRguSGJKGsTDKLzqYJ1Q==", "@joegold", "Joe" },
                    { new Guid("00000000-0000-0000-0004-000000000002"), "andrey@mail.ru", true, "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "GYMOwner", "h7TRguSGJKGsTDKLzqYJ1Q==", "@andrey", "Андрей" },
                    { new Guid("00000000-0000-0000-0004-000000000003"), "gymowner3@mail.ru", true, "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "GYMOwner", "h7TRguSGJKGsTDKLzqYJ1Q==", "@gymowner3", "Owner3" },
                    { new Guid("10000000-0000-0000-0001-000000000001"), "goldgymadministrator@mail.ru", true, "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "Administrator", "h7TRguSGJKGsTDKLzqYJ1Q==", "@goldgymadministrator", "GoldGymAdministrator" },
                    { new Guid("10000000-0000-0000-0001-000000000002"), "almazadministrator@mail.ru", true, "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "Administrator", "h7TRguSGJKGsTDKLzqYJ1Q==", "@almazadministrator", "AlmazAdministrator" },
                    { new Guid("10000000-0000-0000-0001-000000000003"), "administrator3@mail.ru", true, "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "Administrator", "h7TRguSGJKGsTDKLzqYJ1Q==", "@administrator3", "Administrator3" },
                    { new Guid("10000000-0000-0000-0006-000000000001"), "goldgymmanager@mail.ru", true, "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "Manager", "h7TRguSGJKGsTDKLzqYJ1Q==", "@goldgymmanager", "GoldGymManager" },
                    { new Guid("10000000-0000-0000-0006-000000000002"), "almazmanager@mail.ru", true, "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "Manager", "h7TRguSGJKGsTDKLzqYJ1Q==", "@almazmanager", "AlmazManager" },
                    { new Guid("10000000-0000-0000-0006-000000000003"), "manager3@mail.ru", true, "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "Manager", "h7TRguSGJKGsTDKLzqYJ1Q==", "@manager3", "Manager3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000001"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000002"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0001-000000000002"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0001-000000000003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0006-000000000001"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0006-000000000002"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0006-000000000003"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6f35e9ac-2718-4b98-9a39-d3c136217e97"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "ZW62oAyOt2cMhTyfyQeV4ex6buOsCo+442ktnp4ry4g=", "v3kv2EX3EtGm2HjulHm95A==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8699aba2-5ec1-40cf-b186-36ca13c15ea2"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "ZW62oAyOt2cMhTyfyQeV4ex6buOsCo+442ktnp4ry4g=", "v3kv2EX3EtGm2HjulHm95A==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a24ab827-10a5-47bf-86bd-39adeb89b6c9"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "jYQ/ud6dDjGLUgzoIWqCxLyfKA5XLWujcoT00jjwI/k=", "YyaqmwHNHJJ7huxnTd/srg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c35e71b1-01fe-4e96-aa13-35371f792a4f"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "ZW62oAyOt2cMhTyfyQeV4ex6buOsCo+442ktnp4ry4g=", "v3kv2EX3EtGm2HjulHm95A==" });
        }
    }
}
