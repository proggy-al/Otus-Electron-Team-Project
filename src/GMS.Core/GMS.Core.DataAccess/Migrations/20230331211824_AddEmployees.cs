using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GMS.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FitnessClubId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_FitnessClubs_FitnessClubId",
                        column: x => x.FitnessClubId,
                        principalTable: "FitnessClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3518), new Guid("10000000-0000-0000-0006-000000000001"), new DateTime(2023, 3, 31, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3513) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3543), new Guid("10000000-0000-0000-0006-000000000001"), new DateTime(2023, 3, 31, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3542) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3552), new Guid("10000000-0000-0000-0006-000000000002"), new DateTime(2023, 3, 31, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3551) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3559), new Guid("10000000-0000-0000-0006-000000000002"), new DateTime(2023, 3, 31, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3558) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3567), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 31, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3566) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3578), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 31, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3577) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3585), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 31, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3584) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3594), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 31, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3593) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3600), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 31, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3610), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 31, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3618), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 31, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3617) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000c"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3625), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 31, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000d"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3631), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 31, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3630) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000e"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3666), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 31, 21, 18, 24, 532, DateTimeKind.Utc).AddTicks(3665) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FitnessClubId" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0001-000000000001"), new Guid("f0000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0001-000000000002"), new Guid("f0000000-0000-0000-0000-000000000002") },
                    { new Guid("10000000-0000-0000-0001-000000000003"), new Guid("f0000000-0000-0000-0000-000000000003") },
                    { new Guid("10000000-0000-0000-0006-000000000001"), new Guid("f0000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0006-000000000002"), new Guid("f0000000-0000-0000-0000-000000000002") },
                    { new Guid("10000000-0000-0000-0006-000000000003"), new Guid("f0000000-0000-0000-0000-000000000003") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FitnessClubId",
                table: "Employees",
                column: "FitnessClubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7020), new Guid("00000000-0000-0000-0006-000000000001"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7016) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7121), new Guid("00000000-0000-0000-0006-000000000001"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7265), new Guid("00000000-0000-0000-0006-000000000002"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7263) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7282), new Guid("00000000-0000-0000-0006-000000000002"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7281) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7296), new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7295) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7329), new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7327) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7343), new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7342) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7355), new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7354) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7369), new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7367) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7390), new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7401), new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7401) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000c"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7478), new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7477) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000d"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7489), new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7488) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000e"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7529), new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7528) });
        }
    }
}
