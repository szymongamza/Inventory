using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Server.Migrations
{
    public partial class DefaultTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "Model", "SerialNumber" },
                values: new object[] { 1, new DateTime(2022, 9, 16, 14, 7, 44, 76, DateTimeKind.Local).AddTicks(5111), "ATMAT", "Signal", "2220022/31323/23123" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "Model", "SerialNumber" },
                values: new object[] { 2, new DateTime(2022, 9, 16, 14, 7, 44, 76, DateTimeKind.Local).AddTicks(5172), "ATMAT", "Signal Pro", "2220022/31323/23124" });
        }
    }
}
