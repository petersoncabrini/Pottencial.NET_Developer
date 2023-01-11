using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Context;
using ModuloAPI.Models;

namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {

        private readonly ContactBook _context;

        public ContactController(ContactBook context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contact contact) {
            _context.Add(contact);
            _context.SaveChanges();
            return Ok(contact);
        }

        [HttpGet("{id}")]
        public IActionResult GetById (int id) {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update (int id, Contact contact){
            var dbContact = _context.Contacts.Find(id);

            if (dbContact == null)
                return NotFound();

            dbContact.Nome = contact.Nome;
            dbContact.Telefone = contact.Telefone;
            dbContact.Active = contact.Active;

            _context.Contacts.Update(dbContact);
            _context.SaveChanges();

            return Ok(dbContact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id){
            var dbContact = _context.Contacts.Find(id);

            if (dbContact == null)
                return NotFound();
            
            _context.Contacts.Remove(dbContact);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("{GetByName}")]
        public IActionResult GetByName(string name) {
            var contacts = _context.Contacts.Where(x => x.Nome.Contains(name));
            return Ok(contacts);
        }

    }
}