using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMS.Communication.DataAccess.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class NotificationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingNotification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    TrainingDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NotificationPeriod = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(1, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingNotification", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingNotification");
        }
    }
}
