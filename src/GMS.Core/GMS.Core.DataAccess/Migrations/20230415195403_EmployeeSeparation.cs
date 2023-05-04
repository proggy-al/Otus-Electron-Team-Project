using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GMS.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeSeparation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_FitnessClubs_FitnessClubId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_AreaId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_FitnessClubId",
                table: "TimeSlots");

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000c"));

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000d"));

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000e"));

            migrationBuilder.DropColumn(
                name: "FitnessClubId",
                table: "TimeSlots");

            migrationBuilder.AlterColumn<bool>(
                name: "IsBusy",
                table: "TimeSlots",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerId",
                table: "Contracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsApproved",
                table: "Contracts",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrators_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "Id",
                values: new object[]
                {
                    new Guid("10000000-0000-0000-0001-000000000001"),
                    new Guid("10000000-0000-0000-0001-000000000002"),
                    new Guid("10000000-0000-0000-0001-000000000003")
                });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9509), new DateTime(2023, 4, 15, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9506) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9535), new DateTime(2023, 4, 15, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9547), new DateTime(2023, 4, 15, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9546) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9556), new DateTime(2023, 4, 15, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9555) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9566), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 4, 15, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9565) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9578), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 4, 15, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9577) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9586), new Guid("10000000-0000-0000-0006-000000000003"), new DateTime(2023, 4, 15, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9586) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9594), new DateTime(2023, 4, 15, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9593) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9602), new DateTime(2023, 4, 15, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9601) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9612), new DateTime(2023, 4, 15, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9612) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9619), new DateTime(2023, 4, 15, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9618) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FitnessClubId" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0005-000000000001"), new Guid("f0000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0005-000000000002"), new Guid("f0000000-0000-0000-0000-000000000002") },
                    { new Guid("10000000-0000-0000-0005-000000000003"), new Guid("f0000000-0000-0000-0000-000000000003") },
                    { new Guid("10000000-0000-0000-0005-000000000004"), new Guid("f0000000-0000-0000-0000-000000000003") }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                column: "Id",
                values: new object[]
                {
                    new Guid("10000000-0000-0000-0006-000000000001"),
                    new Guid("10000000-0000-0000-0006-000000000002"),
                    new Guid("10000000-0000-0000-0006-000000000003")
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                column: "Id",
                values: new object[]
                {
                    new Guid("10000000-0000-0000-0005-000000000001"),
                    new Guid("10000000-0000-0000-0005-000000000002"),
                    new Guid("10000000-0000-0000-0005-000000000003"),
                    new Guid("10000000-0000-0000-0005-000000000004")
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_AreaId",
                table: "TimeSlots",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_TrainerId",
                table: "TimeSlots",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ManagerId",
                table: "Contracts",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Managers_ManagerId",
                table: "Contracts",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Trainers_TrainerId",
                table: "TimeSlots",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Managers_ManagerId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Trainers_TrainerId",
                table: "TimeSlots");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_AreaId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_TrainerId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ManagerId",
                table: "Contracts");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0005-000000000001"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0005-000000000002"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0005-000000000003"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0005-000000000004"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsBusy",
                table: "TimeSlots",
                type: "boolean",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "FitnessClubId",
                table: "TimeSlots",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ManagerId",
                table: "Contracts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<bool>(
                name: "IsApproved",
                table: "Contracts",
                type: "boolean",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6559), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6557) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6580), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6579) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6589), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6588) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6597), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6596) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6605), null, new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6604) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6616), null, new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6616) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "EndDate", "ManagerId", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6626), null, new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6625) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6633), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6633) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6642), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6641) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6652), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6651) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6660), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6659) });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "EndDate", "IsApproved", "ManagerId", "ProductId", "StartDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-00000000000c"), new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6667), true, new Guid("10000000-0000-0000-0001-000000000003"), new Guid("b0000000-0000-0000-0000-000000000010"), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6667), new Guid("00000000-0000-0000-0002-000000000002") },
                    { new Guid("c0000000-0000-0000-0000-00000000000d"), new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6676), true, new Guid("10000000-0000-0000-0001-000000000003"), new Guid("b0000000-0000-0000-0000-000000000009"), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6675), new Guid("00000000-0000-0000-0002-000000000003") },
                    { new Guid("c0000000-0000-0000-0000-00000000000e"), new DateTime(2024, 4, 3, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6699), true, new Guid("10000000-0000-0000-0001-000000000003"), new Guid("b0000000-0000-0000-0000-000000000009"), new DateTime(2023, 4, 4, 22, 31, 16, 200, DateTimeKind.Utc).AddTicks(6699), new Guid("00000000-0000-0000-0002-000000000003") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_AreaId",
                table: "TimeSlots",
                column: "AreaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_FitnessClubId",
                table: "TimeSlots",
                column: "FitnessClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_FitnessClubs_FitnessClubId",
                table: "TimeSlots",
                column: "FitnessClubId",
                principalTable: "FitnessClubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
