using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GMS.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "FitnessClubs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "character varying(64)", unicode: false, nullable: false),
                    Description = table.Column<string>(type: "character varying(4096)", unicode: false, nullable: true),
                    Address = table.Column<string>(type: "character varying(256)", unicode: false, nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessClubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "character varying(64)", unicode: false, nullable: false),
                    FitnessClubId = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_FitnessClubs_FitnessClubId",
                        column: x => x.FitnessClubId,
                        principalTable: "FitnessClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "character varying(64)", unicode: false, nullable: false),
                    Description = table.Column<string>(type: "character varying(1024)", unicode: false, nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    FitnessClubId = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_FitnessClubs_FitnessClubId",
                        column: x => x.FitnessClubId,
                        principalTable: "FitnessClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "character varying(64)", unicode: false, nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", unicode: false, nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    TrainerId = table.Column<Guid>(type: "uuid", nullable: false),
                    AreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    FitnessClubId = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlots_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSlots_FitnessClubs_FitnessClubId",
                        column: x => x.FitnessClubId,
                        principalTable: "FitnessClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FitnessClubId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_FitnessClubs_FitnessClubId",
                        column: x => x.FitnessClubId,
                        principalTable: "FitnessClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeSlotId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(256)", unicode: false, nullable: true),
                    Points = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FitnessClubs",
                columns: new[] { "Id", "Address", "Description", "Name", "OwnerId" },
                values: new object[,]
                {
                    { new Guid("f0000000-0000-0000-0000-000000000001"), "360 Hampton Dr, Venice, CA 90291, USA", "Gold’s Gym Venice gives you access to everything you need reach your fitness goals: all outdoor workout spaces, weight and strength training areas, a wide selection of free weights, cardio equipment, resistance machines – plus a team of certified Personal Trainers ready to support and motivate you to become the strongest version of yourself. From our beginning as a small bodybuilding gym in 1965 to today, Gold’s Gym delivers a dynamic fitness experience focused on strength and performance. View our local gym membership options and join Gold’s Gym Venice now.", "Gold's Gym Venice", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f0000000-0000-0000-0000-000000000002"), "Россия, Санкт-Петербург, ул. Воскова, д. 16", "Атлетический клуб «Алмаз» является одним из самых известных клубов Санкт-Петербурга и России, развивающих фитнес и бодибилдинг. За более чем 25 летнею историю развития, клуб накопил богатейший опыт в сфере фитнеса и бодибилдинга. Об этом свидетельствуют многочисленные победы воспитанников клуба на международных, Российских и городских соревнованиях по фитнесу и бодибилдингу.Клуб оборудован удобными раздевалками, душевыми, современными системами вентиляции зала.Тренера клуба помогут клиентам составить индивидуальные программы тренировок, скорректируют диету, помогут распланировать распорядок дня, для желающих проведут персональные тренировки.", "Атлетический клуб Алмаз", new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "FitnessClubId", "Name" },
                values: new object[,]
                {
                    { new Guid("a0000000-0000-0000-0000-000000000001"), new Guid("f0000000-0000-0000-0000-000000000001"), "Outdoor workout area" },
                    { new Guid("a0000000-0000-0000-0000-000000000002"), new Guid("f0000000-0000-0000-0000-000000000001"), "Free weights area" },
                    { new Guid("a0000000-0000-0000-0000-000000000003"), new Guid("f0000000-0000-0000-0000-000000000001"), "Functional training area" },
                    { new Guid("a0000000-0000-0000-0000-000000000004"), new Guid("f0000000-0000-0000-0000-000000000001"), "Resistance Machines area" },
                    { new Guid("a0000000-0000-0000-0000-000000000005"), new Guid("f0000000-0000-0000-0000-000000000001"), "Cardio Equipment area" },
                    { new Guid("a0000000-0000-0000-0000-000000000006"), new Guid("f0000000-0000-0000-0000-000000000002"), "Тренажерный зал" },
                    { new Guid("a0000000-0000-0000-0000-000000000007"), new Guid("f0000000-0000-0000-0000-000000000002"), "Зона кардиотренажеров" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "FitnessClubId", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000001"), "Free access to the club for 30 days", new Guid("f0000000-0000-0000-0000-000000000001"), "1-Month Contract", 100, 30 },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), "Free access to the club for 1 year", new Guid("f0000000-0000-0000-0000-000000000001"), "12-Month Contract", 490, 365 },
                    { new Guid("b0000000-0000-0000-0000-000000000003"), "for a month", new Guid("f0000000-0000-0000-0000-000000000001"), "1 personal Training", 65, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), "for a month", new Guid("f0000000-0000-0000-0000-000000000001"), "8 personal Training", 360, 8 },
                    { new Guid("b0000000-0000-0000-0000-000000000005"), "Свободное посещение клуба в течении 1 дня", new Guid("f0000000-0000-0000-0000-000000000002"), "Разовое посещение", 500, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000006"), "Свободное посещение клуба в течении 30 дней", new Guid("f0000000-0000-0000-0000-000000000002"), "Абонемент на месяц", 2000, 30 },
                    { new Guid("b0000000-0000-0000-0000-000000000007"), "на 1 месяц", new Guid("f0000000-0000-0000-0000-000000000002"), "1 персональная тренировка", 2000, 1 },
                    { new Guid("b0000000-0000-0000-0000-000000000008"), "на 1 месяц", new Guid("f0000000-0000-0000-0000-000000000002"), "8 персональных тренировок", 12000, 8 }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "EndDate", "FitnessClubId", "ManagerId", "ProductId", "StartDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-000000000001"), new DateTime(2024, 2, 17, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8684), new Guid("f0000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0006-000000000001"), new Guid("b0000000-0000-0000-0000-000000000002"), new DateTime(2023, 2, 17, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8681), new Guid("00000000-0000-0000-0001-000000000001") },
                    { new Guid("c0000000-0000-0000-0000-000000000002"), new DateTime(2023, 3, 19, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8698), new Guid("f0000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0006-000000000001"), new Guid("b0000000-0000-0000-0000-000000000003"), new DateTime(2023, 2, 17, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8698), new Guid("00000000-0000-0000-0001-000000000001") },
                    { new Guid("c0000000-0000-0000-0000-000000000003"), new DateTime(2023, 3, 19, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8735), new Guid("f0000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0006-000000000002"), new Guid("b0000000-0000-0000-0000-000000000006"), new DateTime(2023, 2, 17, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8734), new Guid("00000000-0000-0000-0001-000000000002") },
                    { new Guid("c0000000-0000-0000-0000-000000000004"), new DateTime(2023, 3, 19, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8743), new Guid("f0000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0006-000000000002"), new Guid("b0000000-0000-0000-0000-000000000008"), new DateTime(2023, 2, 17, 20, 50, 55, 529, DateTimeKind.Utc).AddTicks(8742), new Guid("00000000-0000-0000-0001-000000000002") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_FitnessClubId",
                table: "Areas",
                column: "FitnessClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FitnessClubId",
                table: "Contracts",
                column: "FitnessClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ProductId",
                table: "Contracts",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_FitnessClubId",
                table: "Products",
                column: "FitnessClubId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_AreaId",
                table: "TimeSlots",
                column: "AreaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_FitnessClubId",
                table: "TimeSlots",
                column: "FitnessClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TimeSlotId",
                table: "Trainings",
                column: "TimeSlotId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "FitnessClubs");
        }
    }
}
