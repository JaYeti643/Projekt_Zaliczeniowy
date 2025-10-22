using Lab0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

public class ContactController : Controller
{
    private static Dictionary<int, Contact> _contacts = new()
    {
        {
            3, new Contact()
            {
                Id = 3,
                Name = "Adam",
                Email = "ad@wsei.edu.pl",
                BirthDate = DateOnly.FromDateTime(new DateTime(2000, 03, 11))



            }
        },
        {
            2, new Contact()
            {
                Id = 2,
                Name = "Ewa",
                Email = "Ew@wsei.edu.pl",
                BirthDate = DateOnly.FromDateTime(new DateTime(2000, 03, 12))
                
                
                
            }
        }
    };

    private static int i = 0;
    // GET
    public IActionResult Index()
    {
        return View(_contacts.Values.ToList());
    }

    [HttpGet] //Formularz
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]//Odbiór danych z formularza
    public IActionResult Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            //zapamiętanie nowego kontaktu
            contact.Id = ++i;
            _contacts.Add(contact.Id, contact);
            return RedirectToAction("Index");
        }
        return View(contact);
    }

    public IActionResult Details(int id)
    {
        if (_contacts.ContainsKey(id))
        {
        return View(_contacts[id]);
        }
        else
        {
            return NotFound();
        }
    }
    
    
}