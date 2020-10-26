using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_Data
{
    public class AddressBookEntites:DbContext
    {
        public AddressBookEntites(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
    }
}
