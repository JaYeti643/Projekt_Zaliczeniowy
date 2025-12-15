using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    production_date = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "computers",
                columns: new[] { "Id", "Cpu", "production_date", "Gpu", "Name", "Producent", "Ram" },
                values: new object[,]
                {
                    { 1, "Intel i5-12400", new DateOnly(2022, 5, 10), "NVIDIA GTX 1660", "Dell Inspiron", "Dell", "16GB DDR4" },
                    { 2, "AMD Ryzen 7 5800U", new DateOnly(2021, 11, 20), "Integrated Radeon", "Lenovo ThinkPad", "Lenovo", "32GB DDR4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "computers");
        }
    }
}
