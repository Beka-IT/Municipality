using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Municipality.Migrations
{
    public partial class AlterPaymentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addressee",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "IrrigationPayments");

            migrationBuilder.AddColumn<string>(
                name: "AddresseePin",
                table: "Messages",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderPin",
                table: "IrrigationPayments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddresseePin",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderPin",
                table: "IrrigationPayments");

            migrationBuilder.AddColumn<int>(
                name: "Addressee",
                table: "Messages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "IrrigationPayments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
