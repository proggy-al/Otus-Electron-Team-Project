using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GMS.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataTimeSlots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "AreaId", "DateTime", "Description", "Duration", "Name", "TrainerId" },
                values: new object[,]
                {
                    { new Guid("d0000000-0000-0000-0000-000000000001"), new Guid("a0000000-0000-0000-0000-000000000003"), new DateTime(2023, 6, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Strength and endurance training", 60, "Functional training", new Guid("10000000-0000-0000-0005-000000000001") },
                    { new Guid("d0000000-0000-0000-0000-000000000002"), new Guid("a0000000-0000-0000-0000-000000000007"), new DateTime(2023, 6, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Тренировка на выносливость", 60, "Кардио", new Guid("10000000-0000-0000-0005-000000000002") },
                    { new Guid("d0000000-0000-0000-0000-000000000003"), new Guid("a0000000-0000-0000-0000-000000000008"), new DateTime(2023, 6, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Описание тренировки 3 ФК3", 60, "Запись на тренировку 3 ФК3", new Guid("10000000-0000-0000-0005-000000000003") },
                    { new Guid("d0000000-0000-0000-0000-000000000004"), new Guid("a0000000-0000-0000-0000-000000000008"), new DateTime(2023, 6, 1, 10, 0, 0, 0, DateTimeKind.Utc), "Описание тренировки 4 ФК3", 60, "Запись на тренировку 4 ФК3", new Guid("10000000-0000-0000-0005-000000000003") },
                    { new Guid("d0000000-0000-0000-0000-000000000005"), new Guid("a0000000-0000-0000-0000-000000000008"), new DateTime(2023, 6, 1, 11, 0, 0, 0, DateTimeKind.Utc), "Описание тренировки 5 ФК3", 60, "Запись на тренировку 5 ФК3", new Guid("10000000-0000-0000-0005-000000000003") },
                    { new Guid("d0000000-0000-0000-0000-000000000006"), new Guid("a0000000-0000-0000-0000-000000000009"), new DateTime(2023, 6, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Описание тренировки 6 ФК3", 60, "Запись на тренировку 6 ФК3", new Guid("10000000-0000-0000-0005-000000000004") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000006"));

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
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9566), new DateTime(2023, 4, 15, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9565) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9578), new DateTime(2023, 4, 15, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9577) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 14, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9586), new DateTime(2023, 4, 15, 19, 54, 2, 895, DateTimeKind.Utc).AddTicks(9586) });

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
        }
    }
}
