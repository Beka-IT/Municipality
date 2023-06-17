using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Municipality.Migrations
{
    public partial class AlterRegions10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Messages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Messages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
