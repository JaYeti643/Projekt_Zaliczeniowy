using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace Data;

public class AppDbContext : DbContext
{
    public DbSet<ComputerEntity> Computers { get; set; }

    private string DbPath { get; set; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "computers.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComputerEntity>().HasData(
            new ComputerEntity()
            {
                Id = 1,
                Name = "Dell Inspiron",
                Cpu = "Intel i5-12400",
                Ram = "16GB DDR4",
                Gpu = "NVIDIA GTX 1660",
                Producent = "Dell",
                DateOfProduction = new DateOnly(2022, 5, 10)
            },
            new ComputerEntity()
            {
                Id = 2,
                Name = "Lenovo ThinkPad",
                Cpu = "AMD Ryzen 7 5800U",
                Ram = "32GB DDR4",
                Gpu = "Integrated Radeon",
                Producent = "Lenovo",
                DateOfProduction = new DateOnly(2021, 11, 20)
            }
        );
    }
}