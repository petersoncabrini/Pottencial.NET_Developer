using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModuloMVC.Models;

namespace ModuloMVC.Context
{
    public class ContactBookContext : DbContext
    {
        public ContactBookContext(DbContextOptions<ContactBookContext> options) : base (options)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }

    }
}