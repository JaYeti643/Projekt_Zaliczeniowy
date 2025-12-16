using Data.Entities;

namespace Lab0.Models;

public interface IComputerService
{
    int Add(Computer computer);
    void Delete(int id);
    List<Computer> FindAll();
    Computer? FindById(int id);
    void Update(Computer computer);
    List<ManufacturerEntity> FindAllManufacturers();

    List<Computer> FindPaged(int pageNumber, int pageSize);
    int CountAll();

}