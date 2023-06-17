using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Municipality.Migrations
{
    public partial class AlterRegions6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgriculturalLandId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AgriculturalLandId",
                table: "Users",
                column: "AgriculturalLandId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AgriculturalLands_AgriculturalLandId",
                table: "Users",
                column: "AgriculturalLandId",
                principalTable: "AgriculturalLands",
                principalColumn: "LandQueueNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AgriculturalLands_AgriculturalLandId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AgriculturalLandId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AgriculturalLandId",
                table: "Users");
        }
    }
}
