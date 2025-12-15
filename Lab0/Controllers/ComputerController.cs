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
            int id = _computers.Keys.Count != 0 ? _computers.Keys.Max() : 0;
            computer.Id = id + 1;
            _computers.Add(computer.Id, computer);
            RedirectToAction("Index");

        }
        return View(computer);
    }

    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        if (_computers.Keys.Contains(id))
        {
            return View(_computers[id]);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Edit(Computer computer)
    {
        if (ModelState.IsValid && _computers.ContainsKey(computer.Id))
        {
            _computers[computer.Id] = computer;
            return RedirectToAction("Index");
        }
        return View(computer);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        if (_computers.ContainsKey(id))
        {
            return View(_computers[id]);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        if (_computers.ContainsKey(id))
        {
            return View(_computers[id]);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        if (_computers.ContainsKey(id))
        {
            _computers.Remove(id);
        }
        return RedirectToAction("Index");
    }
}