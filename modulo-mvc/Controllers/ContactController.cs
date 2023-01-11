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

        public IActionResult Edit(int id)
        {
            var contato = _context.Contacts.Find(id);
            if (contato == null)
                return RedirectToAction(nameof(Index));
           
            return View(contato);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            var dbContact = _context.Contacts.Find(contact.Id);
            dbContact.Nome = contact.Nome;
            dbContact.Telefone = contact.Telefone;
            dbContact.Ativo = contact.Ativo;

            _context.Contacts.Update(dbContact);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details (int id)
        {
            var contato = _context.Contacts.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }

        public IActionResult Delete(int id)
        {
            var contato = _context.Contacts.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            var dbContact = _context.Contacts.Find(contact.Id);

            _context.Contacts.Remove(dbContact);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}