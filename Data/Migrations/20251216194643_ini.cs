using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "computers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2025, 12, 16, 20, 46, 42, 994, DateTimeKind.Local).AddTicks(9706),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2025, 12, 15, 22, 9, 10, 777, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "computers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 12, 16, 20, 46, 42, 994, DateTimeKind.Local).AddTicks(9706));

            migrationBuilder.UpdateData(
                table: "computers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2025, 12, 16, 20, 46, 42, 994, DateTimeKind.Local).AddTicks(9706));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "computers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2025, 12, 15, 22, 9, 10, 777, DateTimeKind.Local).AddTicks(1427),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2025, 12, 16, 20, 46, 42, 994, DateTimeKind.Local).AddTicks(9706));

            migrationBuilder.UpdateData(
                table: "computers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 12, 15, 22, 9, 10, 777, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "computers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2025, 12, 15, 22, 9, 10, 777, DateTimeKind.Local).AddTicks(1427));
        }
    }
}
