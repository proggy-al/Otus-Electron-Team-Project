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
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsActive", "PasswordHash", "Role", "Salt", "TelegramUserName", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0002-000000000001"), "johngold@mail.ru", true, "n5zqX3XdybntUcBHO0vdBjRej+QSduTDeFhTRsrOO9k=", "User", "knowPi2QZNuCrHAlMYyt+w==", "@johngold", "John" },
                    { new Guid("00000000-0000-0000-0002-000000000002"), "ivanalmaz@mail.ru", true, "n5zqX3XdybntUcBHO0vdBjRej+QSduTDeFhTRsrOO9k=", "User", "knowPi2QZNuCrHAlMYyt+w==", "@ivanalmaz", "Иван" },
                    { new Guid("00000000-0000-0000-0002-000000000003"), "user3@mail.ru", true, "n5zqX3XdybntUcBHO0vdBjRej+QSduTDeFhTRsrOO9k=", "User", "knowPi2QZNuCrHAlMYyt+w==", "@user3", "User3" },
                    { new Guid("00000000-0000-0000-0004-000000000001"), "joegold@mail.ru", true, "n5zqX3XdybntUcBHO0vdBjRej+QSduTDeFhTRsrOO9k=", "GYMOwner", "knowPi2QZNuCrHAlMYyt+w==", "@joegold", "Joe" },
                    { new Guid("00000000-0000-0000-0004-000000000002"), "andrey@mail.ru", true, "n5zqX3XdybntUcBHO0vdBjRej+QSduTDeFhTRsrOO9k=", "GYMOwner", "knowPi2QZNuCrHAlMYyt+w==", "@andrey", "Андрей" },
                    { new Guid("00000000-0000-0000-0004-000000000003"), "gymowner3@mail.ru", true, "n5zqX3XdybntUcBHO0vdBjRej+QSduTDeFhTRsrOO9k=", "GYMOwner", "knowPi2QZNuCrHAlMYyt+w==", "@gymowner3", "Owner3" },
                    { new Guid("10000000-0000-0000-0001-000000000001"), "goldgymadministrator@mail.ru", true, "3681sgmS5A7DvwlIyHOHJqL0aKD60ImMv7ZEIweBTEs=", "Administrator", "8rPfOLj0A26zoW0rpFVpyA==", "@goldgymadministrator", "GoldGymAdministrator" },
                    { new Guid("10000000-0000-0000-0001-000000000002"), "almazadministrator@mail.ru", true, "3681sgmS5A7DvwlIyHOHJqL0aKD60ImMv7ZEIweBTEs=", "Administrator", "8rPfOLj0A26zoW0rpFVpyA==", "@almazadministrator", "AlmazAdministrator" },
                    { new Guid("10000000-0000-0000-0001-000000000003"), "administrator3@mail.ru", true, "3681sgmS5A7DvwlIyHOHJqL0aKD60ImMv7ZEIweBTEs=", "Administrator", "8rPfOLj0A26zoW0rpFVpyA==", "@administrator3", "Administrator3" },
                    { new Guid("10000000-0000-0000-0006-000000000001"), "goldgymmanager@mail.ru", true, "3681sgmS5A7DvwlIyHOHJqL0aKD60ImMv7ZEIweBTEs=", "Manager", "8rPfOLj0A26zoW0rpFVpyA==", "@goldgymmanager", "GoldGymManager" },
                    { new Guid("10000000-0000-0000-0006-000000000002"), "almazmanager@mail.ru", true, "3681sgmS5A7DvwlIyHOHJqL0aKD60ImMv7ZEIweBTEs=", "Manager", "8rPfOLj0A26zoW0rpFVpyA==", "@almazmanager", "AlmazManager" },
                    { new Guid("10000000-0000-0000-0006-000000000003"), "manager3@mail.ru", true, "3681sgmS5A7DvwlIyHOHJqL0aKD60ImMv7ZEIweBTEs=", "Manager", "8rPfOLj0A26zoW0rpFVpyA==", "@manager3", "Manager3" }
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
        }
    }
}
