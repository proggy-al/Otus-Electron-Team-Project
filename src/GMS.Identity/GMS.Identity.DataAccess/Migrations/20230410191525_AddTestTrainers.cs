using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GMS.Identity.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTestTrainers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000001"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "WNwWAgHxqri/H9AJuQkB1g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000002"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "WNwWAgHxqri/H9AJuQkB1g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000003"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "WNwWAgHxqri/H9AJuQkB1g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "WNwWAgHxqri/H9AJuQkB1g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "WNwWAgHxqri/H9AJuQkB1g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "WNwWAgHxqri/H9AJuQkB1g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0001-000000000001"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "WNwWAgHxqri/H9AJuQkB1g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0001-000000000002"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "WNwWAgHxqri/H9AJuQkB1g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0001-000000000003"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "WNwWAgHxqri/H9AJuQkB1g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0006-000000000001"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "WNwWAgHxqri/H9AJuQkB1g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0006-000000000002"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "WNwWAgHxqri/H9AJuQkB1g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0006-000000000003"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "WNwWAgHxqri/H9AJuQkB1g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6f35e9ac-2718-4b98-9a39-d3c136217e97"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "aXPnL2AR4bbjXMc628LFLxGH0BsefiprENKvBWLMLQM=", "Jv1qConX7hVkbvCBgYkx0g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8699aba2-5ec1-40cf-b186-36ca13c15ea2"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "aXPnL2AR4bbjXMc628LFLxGH0BsefiprENKvBWLMLQM=", "Jv1qConX7hVkbvCBgYkx0g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a24ab827-10a5-47bf-86bd-39adeb89b6c9"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "WNwWAgHxqri/H9AJuQkB1g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c35e71b1-01fe-4e96-aa13-35371f792a4f"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "aXPnL2AR4bbjXMc628LFLxGH0BsefiprENKvBWLMLQM=", "Jv1qConX7hVkbvCBgYkx0g==" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsActive", "PasswordHash", "Role", "Salt", "TelegramUserName", "UserName" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0005-000000000001"), "arnoldgold@mail.ru", true, "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "Coach", "WNwWAgHxqri/H9AJuQkB1g==", "@arnoldgold", "Arnold" },
                    { new Guid("10000000-0000-0000-0005-000000000002"), "alekseialmaz@mail.ru", true, "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "Coach", "WNwWAgHxqri/H9AJuQkB1g==", "@alekseialmaz", "Алексей" },
                    { new Guid("10000000-0000-0000-0005-000000000003"), "trainer3@mail.ru", true, "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "Coach", "WNwWAgHxqri/H9AJuQkB1g==", "@trainer3", "Trainer3" },
                    { new Guid("10000000-0000-0000-0005-000000000004"), "trainer4@mail.ru", true, "tRFFg8yBb53nI34YL7/zQEgaqpFXVCSUnXc8q8M9Xds=", "Coach", "WNwWAgHxqri/H9AJuQkB1g==", "@trainer4", "Trainer4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0005-000000000001"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0005-000000000002"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0005-000000000003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0005-000000000004"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000001"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "h7TRguSGJKGsTDKLzqYJ1Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000002"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "h7TRguSGJKGsTDKLzqYJ1Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000003"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "h7TRguSGJKGsTDKLzqYJ1Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "h7TRguSGJKGsTDKLzqYJ1Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "h7TRguSGJKGsTDKLzqYJ1Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "h7TRguSGJKGsTDKLzqYJ1Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0001-000000000001"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "h7TRguSGJKGsTDKLzqYJ1Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0001-000000000002"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "h7TRguSGJKGsTDKLzqYJ1Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0001-000000000003"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "h7TRguSGJKGsTDKLzqYJ1Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0006-000000000001"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "h7TRguSGJKGsTDKLzqYJ1Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0006-000000000002"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "h7TRguSGJKGsTDKLzqYJ1Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0006-000000000003"),
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "pCNmzUgc/yf9pL2udDqpjfBQOUXvtm5JJkI89K1PhrI=", "h7TRguSGJKGsTDKLzqYJ1Q==" });

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
        }
    }
}
