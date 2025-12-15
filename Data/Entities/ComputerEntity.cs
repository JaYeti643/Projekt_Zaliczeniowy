using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("computers")]
public class ComputerEntity
{
    public int Id { get; set; }

    [MaxLength(50)]
    [Required]
    public string Name { get; set; }

    [MaxLength(50)]
    [Required]
    public string Cpu { get; set; }

    [MaxLength(50)]
    [Required]
    public string Ram { get; set; }

    [MaxLength(50)]
    [Required]
    public string Gpu { get; set; }

    [MaxLength(50)]
    [Required]
    public string Producent { get; set; }

    [Column("production_date")]
    public DateOnly DateOfProduction { get; set; }
}