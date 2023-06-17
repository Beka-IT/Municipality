using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Municipality.Migrations
{
    public partial class AlterRegions8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Irrigation_Round_RoundId",
                table: "Irrigation");

            migrationBuilder.DropForeignKey(
                name: "FK_Round_Villages_VillageId",
                table: "Round");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Round",
                table: "Round");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Irrigation",
                table: "Irrigation");

            migrationBuilder.RenameTable(
                name: "Round",
                newName: "Rounds");

            migrationBuilder.RenameTable(
                name: "Irrigation",
                newName: "Irrigations");

            migrationBuilder.RenameIndex(
                name: "IX_Round_VillageId",
                table: "Rounds",
                newName: "IX_Rounds_VillageId");

            migrationBuilder.RenameIndex(
                name: "IX_Irrigation_RoundId",
                table: "Irrigations",
                newName: "IX_Irrigations_RoundId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Irrigations",
                table: "Irrigations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Irrigations_Rounds_RoundId",
                table: "Irrigations",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Villages_VillageId",
                table: "Rounds",
                column: "VillageId",
                principalTable: "Villages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Irrigations_Rounds_RoundId",
                table: "Irrigations");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Villages_VillageId",
                table: "Rounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Irrigations",
                table: "Irrigations");

            migrationBuilder.RenameTable(
                name: "Rounds",
                newName: "Round");

            migrationBuilder.RenameTable(
                name: "Irrigations",
                newName: "Irrigation");

            migrationBuilder.RenameIndex(
                name: "IX_Rounds_VillageId",
                table: "Round",
                newName: "IX_Round_VillageId");

            migrationBuilder.RenameIndex(
                name: "IX_Irrigations_RoundId",
                table: "Irrigation",
                newName: "IX_Irrigation_RoundId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Round",
                table: "Round",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Irrigation",
                table: "Irrigation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Irrigation_Round_RoundId",
                table: "Irrigation",
                column: "RoundId",
                principalTable: "Round",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Round_Villages_VillageId",
                table: "Round",
                column: "VillageId",
                principalTable: "Villages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
