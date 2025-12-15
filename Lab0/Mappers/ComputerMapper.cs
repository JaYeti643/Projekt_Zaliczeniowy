using Lab0.Models;
using Data.Entities;

namespace Lab0.Mappers;

public class ComputerMapper
{
    public static Computer FromEntity(ComputerEntity entity)
    {
        return new Computer()
        {
            Id = entity.Id,
            Name = entity.Name,
            Cpu = entity.Cpu,
            Ram = entity.Ram,
            Gpu = entity.Gpu,
            Producent = entity.Producent,
            DateOfProduction = entity.DateOfProduction,
            ManufacturerId = entity.ManufacturerId
        };
    }

    public static ComputerEntity ToEntity(Computer model)
    {
        return new ComputerEntity()
        {
            Id = model.Id,
            Name = model.Name,
            Cpu = model.Cpu,
            Ram = model.Ram,
            Gpu = model.Gpu,
            Producent = model.Producent,
            DateOfProduction = model.DateOfProduction ?? DateOnly.FromDateTime(DateTime.Now),
            ManufacturerId = model.ManufacturerId
        };
    }
}