using Data.Entities;
using Lab0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab0.Controllers;

public class ComputerController : Controller
{
    private readonly IComputerService _service;
    
    public ComputerController(IComputerService service)
    {
        _service = service;
    }

    public IActionResult Index(int page = 1)
    {
        int pageSize = 10;

        var computers = _service.FindPaged(page, pageSize);
        int totalCount = _service.CountAll();

        int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = totalPages;

        return View(computers);
    }

    private void InitManufacturers(Computer model)
    {
        model.Manufacturers = _service
            .FindAllManufacturers()
            .Select<ManufacturerEntity, SelectListItem>(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.Title })
            .ToList();
    }

    [HttpGet]
    [HttpGet]
    public IActionResult Create()
    {
        var model = new Computer();
        model.Manufacturers = _service
            .FindAllManufacturers()
            .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Title })
            .ToList();

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(Computer computer)
    {
        if (ModelState.IsValid)
        {
            _service.Add(computer);
            return RedirectToAction("Index");
        }

        
        computer.Manufacturers = _service
            .FindAllManufacturers()
            .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Title })
            .ToList();

        return View(computer);
    }

    [HttpGet]
  
    public IActionResult Edit(int id)
    {
        var computer = _service.FindById(id);
        if (computer == null) return NotFound();

        computer.Manufacturers = _service
            .FindAllManufacturers()
            .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Title })
            .ToList();

        return View(computer);
    }

    [HttpPost]
    public IActionResult Edit(Computer computer)
    {
        if (ModelState.IsValid)
        {
            _service.Update(computer);
            return RedirectToAction("Index");
        }

        computer.Manufacturers = _service
            .FindAllManufacturers()
            .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Title })
            .ToList();

        return View(computer);
    }

    [HttpGet]
   
    public IActionResult Details(int id)
    {
        var computer = _service.FindById(id);
        if (computer == null) return NotFound();

        computer.Manufacturers = _service
            .FindAllManufacturers()
            .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Title })
            .ToList();

        return View(computer);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var computer = _service.FindById(id);
        if (computer == null) return NotFound();
        return View(computer);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _service.Delete(id);
        return RedirectToAction("Index");
    }
}