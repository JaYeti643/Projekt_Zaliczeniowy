using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab0.Models;

public class Computer
{
    [HiddenInput]
    public  int Id { get; set; }

    [Required(ErrorMessage = "Prosze podać Nazwę Komputera!")]
    [StringLength(50)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Proszę podać Nazwę Procesora!")]
    [StringLength(50)]
    public string? Cpu { get; set; }

    [Required(ErrorMessage = "Proszę podać Model i Pojemność pamięci RAM!")]
    [StringLength(50)]
    public string? Ram { get; set; }

    [Required(ErrorMessage = "Proszę podać Model Karty Graficznej!")]
    [StringLength(50)]
    public string? Gpu { get; set; }

    [Required(ErrorMessage = "Proszę podać Nazwę Producenta!")]
    [StringLength(50)]
    public string? Producent { get; set; }

    [Required(ErrorMessage = "Proszę podać Datę Produkcji!")]
    [DataType(DataType.Date)]
    public DateOnly? DateOfProduction { get; set; }
    
    [HiddenInput]
    public int ManufacturerId { get; set; }
    [ValidateNever]
    public List<SelectListItem> Manufacturers { get; set; }
}