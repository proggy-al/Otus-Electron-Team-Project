using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GMS.Identity.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    TelegramUserName = table.Column<string>(type: "TEXT", nullable: false),
                    Salt = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsActive", "PasswordHash", "Role", "Salt", "TelegramUserName", "UserName" },
                values: new object[,]
                {
                    { new Guid("6f35e9ac-2718-4b98-9a39-d3c136217e97"), "user@mail.ru", true, "ZW62oAyOt2cMhTyfyQeV4ex6buOsCo+442ktnp4ry4g=", "User", "v3kv2EX3EtGm2HjulHm95A==", "@user", "User" },
                    { new Guid("8699aba2-5ec1-40cf-b186-36ca13c15ea2"), "dan@mail.ru", true, "ZW62oAyOt2cMhTyfyQeV4ex6buOsCo+442ktnp4ry4g=", "Administrator", "v3kv2EX3EtGm2HjulHm95A==", "@dan", "Dan" },
                    { new Guid("a24ab827-10a5-47bf-86bd-39adeb89b6c9"), "sash@mail.ru", true, "jYQ/ud6dDjGLUgzoIWqCxLyfKA5XLWujcoT00jjwI/k=", "Administrator", "YyaqmwHNHJJ7huxnTd/srg==", "@sash", "Sash" },
                    { new Guid("c35e71b1-01fe-4e96-aa13-35371f792a4f"), "sys@mail.ru", true, "ZW62oAyOt2cMhTyfyQeV4ex6buOsCo+442ktnp4ry4g=", "System", "v3kv2EX3EtGm2HjulHm95A==", "@system", "System" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
