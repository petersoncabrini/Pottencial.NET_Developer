using Microsoft.AspNetCore.Mvc;
using ModuloMVC.Context;

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
    }
}