using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMS.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedData : Migration
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
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    FitnessClubId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    FitnessClubId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    FitnessClubId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    Points = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Areas_FitnessClubId",
                table: "Areas",
                column: "FitnessClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Name",
                table: "Areas",
                column: "Name",
                unique: true);

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
                name: "IX_FitnessClubs_Name",
                table: "FitnessClubs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_FitnessClubId",
                table: "Products",
                column: "FitnessClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_AreaId",
                table: "TimeSlots",
                column: "AreaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_DateTime",
                table: "TimeSlots",
                column: "DateTime",
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
