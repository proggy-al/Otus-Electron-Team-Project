using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GMS.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EditTrainingAndAddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Products_ProductId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TimeSlots_TimeSlotId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Trainings");

            migrationBuilder.AlterColumn<int>(
                name: "Points",
                table: "Trainings",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainerNotes",
                table: "Trainings",
                type: "character varying(256)",
                unicode: false,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2363), new DateTime(2023, 4, 16, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2361) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2385), new DateTime(2023, 4, 16, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2384) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2394), new DateTime(2023, 4, 16, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2394) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2403), new DateTime(2023, 4, 16, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2403) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2412), new DateTime(2023, 4, 16, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2411) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2424), new DateTime(2023, 4, 16, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2424) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2433), new DateTime(2023, 4, 16, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2432) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2441), new DateTime(2023, 4, 16, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2441) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2448), new DateTime(2023, 4, 16, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2448) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2457), new DateTime(2023, 4, 16, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2456) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2464), new DateTime(2023, 4, 16, 20, 28, 54, 438, DateTimeKind.Utc).AddTicks(2463) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000003"),
                column: "IsBusy",
                value: true);

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "AreaId", "DateTime", "Description", "Duration", "IsBusy", "Name", "TrainerId" },
                values: new object[,]
                {
                    { new Guid("d0000000-0000-0000-0000-000000000007"), new Guid("a0000000-0000-0000-0000-000000000009"), new DateTime(2023, 1, 1, 9, 0, 0, 0, DateTimeKind.Utc), "Описание тренировки 7 ФК3", 60, true, "Запись на тренировку 7 ФК3", new Guid("10000000-0000-0000-0005-000000000003") },
                    { new Guid("d0000000-0000-0000-0000-000000000008"), new Guid("a0000000-0000-0000-0000-000000000009"), new DateTime(2023, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), "Описание тренировки 8 ФК3", 60, true, "Запись на тренировку 8 ФК3", new Guid("10000000-0000-0000-0005-000000000003") }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "TimeSlotId", "TrainerNotes", "UserId" },
                values: new object[,]
                {
                    { new Guid("d0000000-0000-0000-0001-000000000001"), new Guid("d0000000-0000-0000-0000-000000000003"), "", new Guid("00000000-0000-0000-0002-000000000003") },
                    { new Guid("d0000000-0000-0000-0001-000000000002"), new Guid("d0000000-0000-0000-0000-000000000007"), "", new Guid("00000000-0000-0000-0002-000000000003") },
                    { new Guid("d0000000-0000-0000-0001-000000000003"), new Guid("d0000000-0000-0000-0000-000000000008"), "", new Guid("00000000-0000-0000-0002-000000000003") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Products_ProductId",
                table: "Contracts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_TimeSlots_TimeSlotId",
                table: "Trainings",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Products_ProductId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_TimeSlots_TimeSlotId",
                table: "Trainings");

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0001-000000000002"));

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0001-000000000003"));

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000008"));

            migrationBuilder.DropColumn(
                name: "TrainerNotes",
                table: "Trainings");

            migrationBuilder.AlterColumn<int>(
                name: "Points",
                table: "Trainings",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Trainings",
                type: "character varying(256)",
                unicode: false,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(857), new DateTime(2023, 4, 15, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(854) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(880), new DateTime(2023, 4, 15, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(893), new DateTime(2023, 4, 15, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(892) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(902), new DateTime(2023, 4, 15, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(901) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(912), new DateTime(2023, 4, 15, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(911) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(926), new DateTime(2023, 4, 15, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(925) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(935), new DateTime(2023, 4, 15, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(935) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(944), new DateTime(2023, 4, 15, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(952), new DateTime(2023, 4, 15, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(952) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(963), new DateTime(2023, 4, 15, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(962) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(971), new DateTime(2023, 4, 15, 19, 55, 42, 27, DateTimeKind.Utc).AddTicks(971) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000003"),
                column: "IsBusy",
                value: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Products_ProductId",
                table: "Contracts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_TimeSlots_TimeSlotId",
                table: "Trainings",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
