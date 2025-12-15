using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace Data;

public class AppDbContext : DbContext
{
    public DbSet<ComputerEntity> Computers { get; set; }
    public DbSet<ManufacturerEntity> Manufacturers { get; set; }

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
       
        modelBuilder.Entity<ManufacturerEntity>()
            .OwnsOne(e => e.Address);

        modelBuilder.Entity<ComputerEntity>()
            .Property(c => c.ManufacturerId)
            .HasDefaultValue(201); 
        
        modelBuilder.Entity<ComputerEntity>()
            .Property(e=>e.Created)
            .HasDefaultValue(DateTime.Now);

        
        modelBuilder.Entity<ComputerEntity>()
            .HasOne(e => e.Manufacturer)
            .WithMany(m => m.Computers)
            .HasForeignKey(e => e.ManufacturerId);

        
        modelBuilder.Entity<ManufacturerEntity>()
            .ToTable("manufacturers")
            .HasData(
                new ManufacturerEntity()
                {
                    Id = 201,
                    Title = "Dell",
                    Nip = "1234567890",
                    Regon = "987654321"
                },
                new ManufacturerEntity()
                {
                    Id = 202,
                    Title = "Lenovo",
                    Nip = "2233445566",
                    Regon = "112233445"
                }
            );

        
        modelBuilder.Entity<ComputerEntity>().HasData(
            new ComputerEntity()
            {
                Id = 1,
                Name = "Dell Inspiron",
                Cpu = "Intel i5-12400",
                Ram = "16GB DDR4",
                Gpu = "NVIDIA GTX 1660",
                Producent = "Dell",
                DateOfProduction = new DateOnly(2022, 5, 10),
                ManufacturerId = 201
            },
            new ComputerEntity()
            {
                Id = 2,
                Name = "Lenovo ThinkPad",
                Cpu = "AMD Ryzen 7 5800U",
                Ram = "32GB DDR4",
                Gpu = "Integrated Radeon",
                Producent = "Lenovo",
                DateOfProduction = new DateOnly(2021, 11, 20),
                ManufacturerId = 202
            }
        );

        
        modelBuilder.Entity<ManufacturerEntity>()
            .OwnsOne(e => e.Address)
            .HasData(
                new { ManufacturerEntityId = 201, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150", Region = "małopolskie" },
                new { ManufacturerEntityId = 202, City = "Warszawa", Street = "Marszałkowska 10", PostalCode = "00-001", Region = "mazowieckie" }
            );
    }
}