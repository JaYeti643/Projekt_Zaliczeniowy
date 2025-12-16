using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly AppDbContext _context;

        public ManufacturerController(AppDbContext context)
        {
            _context = context;
        }

        // Lista producentów
        [HttpGet]
        public IActionResult Index()
        {
            var manufacturers = _context.Manufacturers.ToList();
            return View(manufacturers);
        }

        // Dodawanie
        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(ManufacturerEntity manufacturer)
        {
            if (ModelState.IsValid)
            {
                _context.Manufacturers.Add(manufacturer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }

        // Edycja
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var manufacturer = _context.Manufacturers.Find(id);
            if (manufacturer == null) return NotFound();
            return View(manufacturer);
        }

        [HttpPost]
        public IActionResult Edit(ManufacturerEntity manufacturer)
        {
            if (ModelState.IsValid)
            {
                _context.Manufacturers.Update(manufacturer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }
        

        // Usuwanie
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var manufacturer = _context.Manufacturers.Find(id);
            if (manufacturer == null) return NotFound();
            return View(manufacturer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var manufacturer = _context.Manufacturers.Find(id);
            if (manufacturer != null)
            {
                _context.Manufacturers.Remove(manufacturer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}