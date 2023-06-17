using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Municipality.Migrations
{
    public partial class AlterIrrigationTable59 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasturePayment_Pastures_PastureId",
                table: "PasturePayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PasturePayment",
                table: "PasturePayment");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "Pastures");

            migrationBuilder.RenameTable(
                name: "PasturePayment",
                newName: "PasturePayments");

            migrationBuilder.RenameIndex(
                name: "IX_PasturePayment_PastureId",
                table: "PasturePayments",
                newName: "IX_PasturePayments_PastureId");

            migrationBuilder.AddColumn<bool>(
                name: "IsPastureTime",
                table: "Villages",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PasturePayments",
                table: "PasturePayments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PasturePayments_Pastures_PastureId",
                table: "PasturePayments",
                column: "PastureId",
                principalTable: "Pastures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasturePayments_Pastures_PastureId",
                table: "PasturePayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PasturePayments",
                table: "PasturePayments");

            migrationBuilder.DropColumn(
                name: "IsPastureTime",
                table: "Villages");

            migrationBuilder.RenameTable(
                name: "PasturePayments",
                newName: "PasturePayment");

            migrationBuilder.RenameIndex(
                name: "IX_PasturePayments_PastureId",
                table: "PasturePayment",
                newName: "IX_PasturePayment_PastureId");

            migrationBuilder.AddColumn<int>(
                name: "Season",
                table: "Pastures",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PasturePayment",
                table: "PasturePayment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PasturePayment_Pastures_PastureId",
                table: "PasturePayment",
                column: "PastureId",
                principalTable: "Pastures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
