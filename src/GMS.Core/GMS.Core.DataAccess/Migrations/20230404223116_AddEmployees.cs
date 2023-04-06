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
            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerId",
                table: "Contracts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6559), new Guid("10000000-0000-0000-0006-000000000001"), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6557) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6580), new Guid("10000000-0000-0000-0006-000000000001"), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6579) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6589), new Guid("10000000-0000-0000-0006-000000000002"), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6588) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6597), new Guid("10000000-0000-0000-0006-000000000002"), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6596) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "EndDate", "IsApproved", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6605), false, null, new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6604) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "EndDate", "IsApproved", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6616), false, null, new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6616) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "EndDate", "IsApproved", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6626), false, null, new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6625) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6633), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6633) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6642), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6641) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6652), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6651) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "EndDate", "ManagerId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6660), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6659), new Guid("00000000-0000-0000-0002-000000000002") });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000c"),
                columns: new[] { "EndDate", "ManagerId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6667), new Guid("10000000-0000-0000-0001-000000000003"), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6667), new Guid("00000000-0000-0000-0002-000000000002") });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000d"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6676), new Guid("10000000-0000-0000-0001-000000000003"), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6675) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000e"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6699), new Guid("10000000-0000-0000-0001-000000000003"), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6699) });

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

            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerId",
                table: "Contracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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
                columns: new[] { "EndDate", "IsApproved", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7296), true, new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7295) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "EndDate", "IsApproved", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7329), true, new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7327) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "EndDate", "IsApproved", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7343), true, new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7342) });

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
                columns: new[] { "EndDate", "ManagerId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7401), new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7401), new Guid("00000000-0000-0000-0002-000000000003") });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000c"),
                columns: new[] { "EndDate", "ManagerId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7478), new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7477), new Guid("00000000-0000-0000-0002-000000000003") });

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
