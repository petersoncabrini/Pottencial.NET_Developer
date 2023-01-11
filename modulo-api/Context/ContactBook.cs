using Microsoft.EntityFrameworkCore;
using ModuloAPI.Models;

namespace ModuloAPI.Context
{
    public class ContactBook: DbContext
    {
        public ContactBook(DbContextOptions<ContactBook> options) : base (options){

        }

        public DbSet<Contact> Contacts { get; set; }

    }
}