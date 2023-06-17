using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Municipality.Migrations
{
    public partial class AlterRoundTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Queues_RoundId",
                table: "Queues",
                column: "RoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Queues_Rounds_RoundId",
                table: "Queues",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Queues_Rounds_RoundId",
                table: "Queues");

            migrationBuilder.DropIndex(
                name: "IX_Queues_RoundId",
                table: "Queues");
        }
    }
}
