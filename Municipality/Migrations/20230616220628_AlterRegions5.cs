using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Municipality.Migrations
{
    public partial class AlterRegions5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Users",
                newName: "Fullname");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "VillageId");

            migrationBuilder.AlterColumn<int>(
                name: "VillageId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Pin",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Pin");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VillageId",
                table: "Users",
                column: "VillageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Villages_VillageId",
                table: "Users",
                column: "VillageId",
                principalTable: "Villages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Villages_VillageId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_VillageId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Pin",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "VillageId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Users",
                newName: "Login");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
