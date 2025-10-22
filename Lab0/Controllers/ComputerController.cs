using Lab0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

public class ComputerController : Controller
{
    static Dictionary<int, Computer> _computers = new Dictionary<int, Computer>();
   
    private static int i = 0;
    // GET
    public IActionResult Index()
    {
        return View(_computers.Values.ToList());
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
            computer.Id = ++i;
            _computers.Add(computer.Id, computer);
            RedirectToAction("Index");

        }
        return View(computer);
    }
}