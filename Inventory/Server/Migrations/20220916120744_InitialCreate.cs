using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "Model", "SerialNumber" },
                values: new object[] { 1, new DateTime(2022, 9, 16, 14, 7, 44, 76, DateTimeKind.Local).AddTicks(5111), "ATMAT", "Signal", "2220022/31323/23123" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "Model", "SerialNumber" },
                values: new object[] { 2, new DateTime(2022, 9, 16, 14, 7, 44, 76, DateTimeKind.Local).AddTicks(5172), "ATMAT", "Signal Pro", "2220022/31323/23124" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
