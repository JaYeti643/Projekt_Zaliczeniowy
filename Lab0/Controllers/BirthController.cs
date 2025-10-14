using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

public class BirthController : Controller
{
    // GET
    public IActionResult Form(BirthController model)
    {
        return View();
    }
}