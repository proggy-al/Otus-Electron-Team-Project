using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GMS.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Rev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_FitnessClubs_FitnessClubId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_FitnessClubId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ProductId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "FitnessClubId",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Trainings",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "TimeSlots",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Products",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "FitnessClubs",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Contracts",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Areas",
                newName: "IsDeleted");

            migrationBuilder.AlterColumn<int>(
                name: "Points",
                table: "Trainings",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "IsBusy",
                table: "TimeSlots",
                type: "boolean",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Contracts",
                type: "boolean",
                nullable: true,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "EndDate", "IsApproved", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7020), true, new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7016), new Guid("00000000-0000-0000-0002-000000000001") });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "EndDate", "IsApproved", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7121), true, new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7118), new Guid("00000000-0000-0000-0002-000000000001") });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "EndDate", "IsApproved", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7265), true, new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7263), new Guid("00000000-0000-0000-0002-000000000002") });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "EndDate", "IsApproved", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7282), true, new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7281), new Guid("00000000-0000-0000-0002-000000000002") });

            migrationBuilder.UpdateData(
                table: "FitnessClubs",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000001"),
                columns: new[] { "Description", "OwnerId" },
                values: new object[] { "The Original Home of Serious Training", new Guid("00000000-0000-0000-0004-000000000001") });

            migrationBuilder.UpdateData(
                table: "FitnessClubs",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000002"),
                columns: new[] { "Description", "OwnerId" },
                values: new object[] { "Персональные тренировки по фитнесу и бодибилдингу", new Guid("00000000-0000-0000-0004-000000000002") });

            migrationBuilder.InsertData(
                table: "FitnessClubs",
                columns: new[] { "Id", "Address", "Description", "Name", "OwnerId" },
                values: new object[,]
                {
                    { new Guid("f0000000-0000-0000-0000-000000000003"), "Адрес ФК 3", "Персональные тренировки ФК 3", "Фитнес клуб 3", new Guid("00000000-0000-0000-0004-000000000003") },
                    { new Guid("f0000000-0000-0000-0000-000000000004"), "Адрес ФК 4", "Персональные тренировки ФК 4", "Фитнес клуб 4", new Guid("00000000-0000-0000-0004-000000000003") },
                    { new Guid("f0000000-0000-0000-0000-000000000005"), "Адрес ФК 5", "Персональные тренировки ФК 5", "Фитнес клуб 5", new Guid("00000000-0000-0000-0004-000000000003") },
                    { new Guid("f0000000-0000-0000-0000-000000000006"), "Адрес ФК 6", "Персональные тренировки ФК 6", "Фитнес клуб 6", new Guid("00000000-0000-0000-0004-000000000003") }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                columns: new[] { "Description", "Name", "Quantity" },
                values: new object[] { "Cardio training", "1 personal Training", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                columns: new[] { "Description", "Name", "Price", "Quantity" },
                values: new object[] { "Cardio training", "8 personal Training", 600, 8 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                columns: new[] { "Description", "Price" },
                values: new object[] { "Functional training", 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                columns: new[] { "Description", "Price" },
                values: new object[] { "Functional training", 600 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Бодибилдинг", "1 персональная тренировка", 80 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                columns: new[] { "Description", "Name", "Price", "Quantity" },
                values: new object[] { "Бодибилдинг", "8 персональных тренировок", 480, 8 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                columns: new[] { "Description", "Price" },
                values: new object[] { "Кардио", 80 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                columns: new[] { "Description", "Price" },
                values: new object[] { "Кардио", 480 });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "FitnessClubId", "Name" },
                values: new object[,]
                {
                    { new Guid("a0000000-0000-0000-0000-000000000008"), new Guid("f0000000-0000-0000-0000-000000000003"), "Зона 8 ФК3" },
                    { new Guid("a0000000-0000-0000-0000-000000000009"), new Guid("f0000000-0000-0000-0000-000000000003"), "Зона 9 ФК3" },
                    { new Guid("a0000000-0000-0000-0000-00000000000a"), new Guid("f0000000-0000-0000-0000-000000000003"), "Зона 10 ФК3" }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "FitnessClubId", "IsDeleted", "Name" },
                values: new object[] { new Guid("a0000000-0000-0000-0000-00000000000b"), new Guid("f0000000-0000-0000-0000-000000000003"), true, "Зона 11 ФК3" });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "FitnessClubId", "Name" },
                values: new object[,]
                {
                    { new Guid("a0000000-0000-0000-0000-00000000000c"), new Guid("f0000000-0000-0000-0000-000000000003"), "Зона 12 ФК3" },
                    { new Guid("a0000000-0000-0000-0000-00000000000d"), new Guid("f0000000-0000-0000-0000-000000000003"), "Зона 13 ФК3" },
                    { new Guid("a0000000-0000-0000-0000-00000000000e"), new Guid("f0000000-0000-0000-0000-000000000003"), "Зона 14 ФК3" },
                    { new Guid("a0000000-0000-0000-0000-00000000000f"), new Guid("f0000000-0000-0000-0000-000000000003"), "Зона 15 ФК3" },
                    { new Guid("a0000000-0000-0000-0000-000000000010"), new Guid("f0000000-0000-0000-0000-000000000003"), "Зона 16 ФК3" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "FitnessClubId", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000009"), "1 персональня тренировка ФК3", new Guid("f0000000-0000-0000-0000-000000000003"), "Продукт 9 ФК3", 10, 1 },
                    { new Guid("b0000000-0000-0000-0000-00000000000a"), "2 персональные тренировки ФК3", new Guid("f0000000-0000-0000-0000-000000000003"), "Продукт 10 ФК3", 20, 2 },
                    { new Guid("b0000000-0000-0000-0000-00000000000b"), "3 персональные тренировки ФК3", new Guid("f0000000-0000-0000-0000-000000000003"), "Продукт 11 ФК3", 30, 3 },
                    { new Guid("b0000000-0000-0000-0000-00000000000c"), "4 персональные тренировки ФК3", new Guid("f0000000-0000-0000-0000-000000000003"), "Продукт 12 ФК3", 40, 4 },
                    { new Guid("b0000000-0000-0000-0000-00000000000d"), "5 персональных тренировок ФК3", new Guid("f0000000-0000-0000-0000-000000000003"), "Продукт 13 ФК3", 50, 5 },
                    { new Guid("b0000000-0000-0000-0000-00000000000e"), "6 персональных тренировок ФК3", new Guid("f0000000-0000-0000-0000-000000000003"), "Продукт 14 ФК3", 60, 6 },
                    { new Guid("b0000000-0000-0000-0000-00000000000f"), "7 персональных тренировок ФК3", new Guid("f0000000-0000-0000-0000-000000000003"), "Продукт 15 ФК3", 70, 7 },
                    { new Guid("b0000000-0000-0000-0000-000000000010"), "8 персональных тренировок ФК3", new Guid("f0000000-0000-0000-0000-000000000003"), "Продукт 16 ФК3", 80, 8 },
                    { new Guid("b0000000-0000-0000-0000-000000000011"), "9 персональных тренировок ФК3", new Guid("f0000000-0000-0000-0000-000000000003"), "Продукт 17 ФК3", 90, 9 },
                    { new Guid("b0000000-0000-0000-0000-000000000012"), "10 персональных тренировок ФК3", new Guid("f0000000-0000-0000-0000-000000000003"), "Продукт 18 ФК3", 100, 10 }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "EndDate", "IsApproved", "ManagerId", "ProductId", "StartDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-000000000005"), new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7296), true, new Guid("00000000-0000-0000-0006-000000000003"), new Guid("b0000000-0000-0000-0000-000000000009"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7295), new Guid("00000000-0000-0000-0002-000000000003") },
                    { new Guid("c0000000-0000-0000-0000-000000000006"), new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7329), true, new Guid("00000000-0000-0000-0006-000000000003"), new Guid("b0000000-0000-0000-0000-00000000000a"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7327), new Guid("00000000-0000-0000-0002-000000000003") },
                    { new Guid("c0000000-0000-0000-0000-000000000007"), new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7343), true, new Guid("00000000-0000-0000-0006-000000000003"), new Guid("b0000000-0000-0000-0000-00000000000b"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7342), new Guid("00000000-0000-0000-0002-000000000003") },
                    { new Guid("c0000000-0000-0000-0000-000000000008"), new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7355), true, new Guid("00000000-0000-0000-0006-000000000003"), new Guid("b0000000-0000-0000-0000-00000000000c"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7354), new Guid("00000000-0000-0000-0002-000000000003") },
                    { new Guid("c0000000-0000-0000-0000-000000000009"), new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7369), true, new Guid("00000000-0000-0000-0006-000000000003"), new Guid("b0000000-0000-0000-0000-00000000000d"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7367), new Guid("00000000-0000-0000-0002-000000000003") },
                    { new Guid("c0000000-0000-0000-0000-00000000000a"), new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7390), true, new Guid("00000000-0000-0000-0006-000000000003"), new Guid("b0000000-0000-0000-0000-00000000000e"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7389), new Guid("00000000-0000-0000-0002-000000000003") },
                    { new Guid("c0000000-0000-0000-0000-00000000000b"), new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7401), true, new Guid("00000000-0000-0000-0006-000000000003"), new Guid("b0000000-0000-0000-0000-00000000000f"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7401), new Guid("00000000-0000-0000-0002-000000000003") },
                    { new Guid("c0000000-0000-0000-0000-00000000000c"), new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7478), true, new Guid("00000000-0000-0000-0006-000000000003"), new Guid("b0000000-0000-0000-0000-000000000010"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7477), new Guid("00000000-0000-0000-0002-000000000003") },
                    { new Guid("c0000000-0000-0000-0000-00000000000d"), new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7489), true, new Guid("00000000-0000-0000-0006-000000000003"), new Guid("b0000000-0000-0000-0000-000000000009"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7488), new Guid("00000000-0000-0000-0002-000000000003") },
                    { new Guid("c0000000-0000-0000-0000-00000000000e"), new DateTime(2024, 3, 25, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7529), true, new Guid("00000000-0000-0000-0006-000000000003"), new Guid("b0000000-0000-0000-0000-000000000009"), new DateTime(2023, 3, 26, 23, 3, 17, 545, DateTimeKind.Utc).AddTicks(7528), new Guid("00000000-0000-0000-0002-000000000003") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ProductId",
                table: "Contracts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contracts_ProductId",
                table: "Contracts");

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-00000000000a"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-00000000000b"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-00000000000c"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-00000000000d"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-00000000000e"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-00000000000f"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000a"));

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-00000000000b"));

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

            migrationBuilder.DeleteData(
                table: "FitnessClubs",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "FitnessClubs",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "FitnessClubs",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "FitnessClubs",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DropColumn(
                name: "IsBusy",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Trainings",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "TimeSlots",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Products",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "FitnessClubs",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Contracts",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Areas",
                newName: "Deleted");

            migrationBuilder.AlterColumn<int>(
                name: "Points",
                table: "Trainings",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FitnessClubId",
                table: "Contracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "EndDate", "FitnessClubId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 2, 17, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8684), new Guid("f0000000-0000-0000-0000-000000000001"), new DateTime(2023, 2, 17, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8681), new Guid("00000000-0000-0000-0001-000000000001") });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "EndDate", "FitnessClubId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2023, 3, 19, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8698), new Guid("f0000000-0000-0000-0000-000000000001"), new DateTime(2023, 2, 17, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8698), new Guid("00000000-0000-0000-0001-000000000001") });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "EndDate", "FitnessClubId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2023, 3, 19, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8735), new Guid("f0000000-0000-0000-0000-000000000002"), new DateTime(2023, 2, 17, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8734), new Guid("00000000-0000-0000-0001-000000000002") });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "EndDate", "FitnessClubId", "StartDate", "UserId" },
                values: new object[] { new DateTime(2023, 3, 19, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8743), new Guid("f0000000-0000-0000-0000-000000000002"), new DateTime(2023, 2, 17, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8742), new Guid("00000000-0000-0000-0001-000000000002") });

            migrationBuilder.UpdateData(
                table: "FitnessClubs",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000001"),
                columns: new[] { "Description", "OwnerId" },
                values: new object[] { "Gold’s Gym Venice gives you access to everything you need reach your fitness goals: all outdoor workout spaces, weight and strength training areas, a wide selection of free weights, cardio equipment, resistance machines – plus a team of certified Personal Trainers ready to support and motivate you to become the strongest version of yourself. From our beginning as a small bodybuilding gym in 1965 to today, Gold’s Gym delivers a dynamic fitness experience focused on strength and performance. View our local gym membership options and join Gold’s Gym Venice now.", new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.UpdateData(
                table: "FitnessClubs",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000002"),
                columns: new[] { "Description", "OwnerId" },
                values: new object[] { "Атлетический клуб «Алмаз» является одним из самых известных клубов Санкт-Петербурга и России, развивающих фитнес и бодибилдинг. За более чем 25 летнею историю развития, клуб накопил богатейший опыт в сфере фитнеса и бодибилдинга. Об этом свидетельствуют многочисленные победы воспитанников клуба на международных, Российских и городских соревнованиях по фитнесу и бодибилдингу.Клуб оборудован удобными раздевалками, душевыми, современными системами вентиляции зала.Тренера клуба помогут клиентам составить индивидуальные программы тренировок, скорректируют диету, помогут распланировать распорядок дня, для желающих проведут персональные тренировки.", new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                columns: new[] { "Description", "Name", "Quantity" },
                values: new object[] { "Free access to the club for 30 days", "1-Month Contract", 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                columns: new[] { "Description", "Name", "Price", "Quantity" },
                values: new object[] { "Free access to the club for 1 year", "12-Month Contract", 490, 365 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                columns: new[] { "Description", "Price" },
                values: new object[] { "for a month", 65 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                columns: new[] { "Description", "Price" },
                values: new object[] { "for a month", 360 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Свободное посещение клуба в течении 1 дня", "Разовое посещение", 500 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                columns: new[] { "Description", "Name", "Price", "Quantity" },
                values: new object[] { "Свободное посещение клуба в течении 30 дней", "Абонемент на месяц", 2000, 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                columns: new[] { "Description", "Price" },
                values: new object[] { "на 1 месяц", 2000 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                columns: new[] { "Description", "Price" },
                values: new object[] { "на 1 месяц", 12000 });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FitnessClubId",
                table: "Contracts",
                column: "FitnessClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ProductId",
                table: "Contracts",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_FitnessClubs_FitnessClubId",
                table: "Contracts",
                column: "FitnessClubId",
                principalTable: "FitnessClubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
