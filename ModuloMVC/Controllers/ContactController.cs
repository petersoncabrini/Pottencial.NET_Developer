using Microsoft.AspNetCore.Mvc;
using ModuloMVC.Context;
using ModuloMVC.Models;

namespace ModuloMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactBookContext _context;

        public ContactController(ContactBookContext context)
        {
            _context = context;
        }

        public IActionResult Index(){
            var contatos = _context.Contacts.ToList();
            return View(contatos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }
    }
}