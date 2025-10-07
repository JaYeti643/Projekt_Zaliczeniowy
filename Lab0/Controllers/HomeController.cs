using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab0.Models;

namespace Lab0.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Age(DateTime date)
    {
        ViewBag.Result = DateTime.Now.Year - date.Year ;
        return View();
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Calculator(double? x, double? y, [FromQuery(Name = "operator")]string op)
    {
       //  string? x = Request.Query["x"];
       // string? y = Request.Query["y"];
       // string? op = Request.Query["op"];
       // double xval = Convert.ToDouble(x);
       // double yval = Convert.ToDouble(y);
       // double result = xval + yval;
       // ViewBag.Result = result; 
       if (x is null || y is null)
       {
           
           return View("CalculatorError", "Brak wartości x lub y!");
       }
       switch (op)
       {
           case"add":
               ViewBag.Result = $"{x} + {y} = {x + y}";
               break;
           case"sub":
               ViewBag.Result = $"{x} - {y} = {x - y}";
               break;
           case"mul":
               ViewBag.Result = $"{x} * {y} = {x * y}";
               break;
           case"div":
               ViewBag.Result = $"{x} / {y} = {x / y}";
               break;
           default:
               ViewBag.Result = "Error";
               break;
       }
       
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}