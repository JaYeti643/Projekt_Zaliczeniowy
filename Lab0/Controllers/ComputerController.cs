using Lab0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

public class ComputerController : Controller
{
    private readonly IComputerService _service;

    public ComputerController(IComputerService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        var computers = _service.FindAll();
        return View(computers);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Computer computer)
    {
        if (ModelState.IsValid)
        {
            _service.Add(computer);
            return RedirectToAction("Index");
        }
        return View(computer);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var computer = _service.FindById(id);
        if (computer == null) return NotFound();
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
        return View(computer);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var computer = _service.FindById(id);
        if (computer == null) return NotFound();
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