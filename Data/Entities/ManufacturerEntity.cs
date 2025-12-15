using System.Collections.Generic;

namespace Data.Entities;

public class ManufacturerEntity
{
    public int Id { get; set; }
    public string Title { get; set; }   
    public string Nip { get; set; }
    public string Regon { get; set; }
    public Address? Address { get; set; }

    public ISet<ComputerEntity> Computers { get; set; }
}

public class Address
{
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string Region { get; set; }
}