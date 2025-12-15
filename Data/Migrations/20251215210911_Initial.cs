using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Nip = table.Column<string>(type: "TEXT", nullable: false),
                    Regon = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Region = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Cpu = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Ram = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Gpu = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Producent = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    production_date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 201),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2025, 12, 15, 22, 9, 10, 777, DateTimeKind.Local).AddTicks(1427))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_computers_manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "manufacturers",
                columns: new[] { "Id", "Address_City", "Address_PostalCode", "Address_Region", "Address_Street", "Nip", "Regon", "Title" },
                values: new object[,]
                {
                    { 201, "Kraków", "31-150", "małopolskie", "Św. Filipa 17", "1234567890", "987654321", "Dell" },
                    { 202, "Warszawa", "00-001", "mazowieckie", "Marszałkowska 10", "2233445566", "112233445", "Lenovo" }
                });

            migrationBuilder.InsertData(
                table: "computers",
                columns: new[] { "Id", "Cpu", "production_date", "Gpu", "ManufacturerId", "Name", "Producent", "Ram" },
                values: new object[,]
                {
                    { 1, "Intel i5-12400", new DateOnly(2022, 5, 10), "NVIDIA GTX 1660", 201, "Dell Inspiron", "Dell", "16GB DDR4" },
                    { 2, "AMD Ryzen 7 5800U", new DateOnly(2021, 11, 20), "Integrated Radeon", 202, "Lenovo ThinkPad", "Lenovo", "32GB DDR4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_computers_ManufacturerId",
                table: "computers",
                column: "ManufacturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "computers");

            migrationBuilder.DropTable(
                name: "manufacturers");
        }
    }
}
