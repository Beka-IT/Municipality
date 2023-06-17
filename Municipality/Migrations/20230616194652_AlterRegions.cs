using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Municipality.Migrations
{
    public partial class AlterRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Villages_DistrictId",
                table: "Villages",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_RegionId",
                table: "Districts",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Regions_RegionId",
                table: "Districts",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Villages_Districts_DistrictId",
                table: "Villages",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Regions_RegionId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Villages_Districts_DistrictId",
                table: "Villages");

            migrationBuilder.DropIndex(
                name: "IX_Villages_DistrictId",
                table: "Villages");

            migrationBuilder.DropIndex(
                name: "IX_Districts_RegionId",
                table: "Districts");
        }
    }
}
