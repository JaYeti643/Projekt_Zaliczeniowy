using Lab0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Form()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Result(CalculatorModel model)
    {
        if (!model.IsValid())
        {
            return View("Error", "Nie można wykonać obliczeń");
        }
        ViewBag.Result = model.Result;
        return View("Calculator");
    }
    
    
}