using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Municipality.Migrations
{
    public partial class AlterRegions7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "AgriculturalLands");

            migrationBuilder.DropColumn(
                name: "SowingDurationInHours",
                table: "AgriculturalLands");

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CoastForAnHectare = table.Column<decimal>(type: "TEXT", nullable: false),
                    VillageId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Round_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Irrigation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoundId = table.Column<int>(type: "INTEGER", nullable: false),
                    AgriculturalLandId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Irrigation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Irrigation_Round_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Round",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Irrigation_RoundId",
                table: "Irrigation",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_VillageId",
                table: "Round",
                column: "VillageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Irrigation");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "AgriculturalLands",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SowingDurationInHours",
                table: "AgriculturalLands",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
