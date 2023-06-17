using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Municipality.Migrations
{
    public partial class AlterIrrigationTable57 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Pets");

            migrationBuilder.AddColumn<string>(
                name: "OwnerPin",
                table: "Pets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerPin",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Pets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
