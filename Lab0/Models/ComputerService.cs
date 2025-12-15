using Lab0.Models;
using Data;
using Data.Entities;
using Lab0.Mappers;

public class ComputerService : IComputerService
{
    private AppDbContext _context;

    public ComputerService(AppDbContext context)
    {
        _context = context;
    }

    public int Add(Computer computer)
    {
        var e = _context.Computers.Add(ComputerMapper.ToEntity(computer));
        _context.SaveChanges();
        return e.Entity.Id;
    }

    public void Delete(int id)
    {
        ComputerEntity? find = _context.Computers.Find(id);
        if (find != null)
        {
            _context.Computers.Remove(find);
            _context.SaveChanges();
        }
    }

    public List<Computer> FindAll()
    {
        return _context.Computers.Select(e => ComputerMapper.FromEntity(e)).ToList();
    }

    public Computer? FindById(int id)
    {
        var entity = _context.Computers.Find(id);
        return entity != null ? ComputerMapper.FromEntity(entity) : null;
    }

    public void Update(Computer computer)
    {
        _context.Computers.Update(ComputerMapper.ToEntity(computer));
        _context.SaveChanges();
    }

    public List<ManufacturerEntity> FindAllManufacturers()
    {
        return _context.Manufacturers.ToList();
    }
}

