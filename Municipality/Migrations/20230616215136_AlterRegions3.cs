using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Municipality.Migrations
{
    public partial class AlterRegions3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgricultureAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Area = table.Column<double>(type: "REAL", nullable: false),
                    VillageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgricultureAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgricultureAreas_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgriculturalLands",
                columns: table => new
                {
                    LandQueueNumber = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Area = table.Column<double>(type: "REAL", nullable: false),
                    SowingDurationInHours = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    AgricultureAreaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriculturalLands", x => x.LandQueueNumber);
                    table.ForeignKey(
                        name: "FK_AgriculturalLands_AgricultureAreas_AgricultureAreaId",
                        column: x => x.AgricultureAreaId,
                        principalTable: "AgricultureAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgriculturalLands_AgricultureAreaId",
                table: "AgriculturalLands",
                column: "AgricultureAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureAreas_VillageId",
                table: "AgricultureAreas",
                column: "VillageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgriculturalLands");

            migrationBuilder.DropTable(
                name: "AgricultureAreas");
        }
    }
}
