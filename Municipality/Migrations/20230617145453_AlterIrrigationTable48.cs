using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Municipality.Migrations
{
    public partial class AlterIrrigationTable48 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pastures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Area = table.Column<decimal>(type: "TEXT", nullable: false),
                    CurrentFreeArea = table.Column<decimal>(type: "TEXT", nullable: false),
                    VillageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pastures_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserPin = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Users_UserPin",
                        column: x => x.UserPin,
                        principalTable: "Users",
                        principalColumn: "Pin");
                });

            migrationBuilder.CreateTable(
                name: "PasturePayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PastureId = table.Column<int>(type: "INTEGER", nullable: false),
                    Area = table.Column<decimal>(type: "TEXT", nullable: false),
                    SenderPin = table.Column<string>(type: "TEXT", nullable: false),
                    ReceiptImage = table.Column<byte[]>(type: "BLOB", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasturePayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasturePayment_Pastures_PastureId",
                        column: x => x.PastureId,
                        principalTable: "Pastures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PasturePayment_PastureId",
                table: "PasturePayment",
                column: "PastureId");

            migrationBuilder.CreateIndex(
                name: "IX_Pastures_VillageId",
                table: "Pastures",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserPin",
                table: "Pets",
                column: "UserPin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasturePayment");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Pastures");
        }
    }
}
