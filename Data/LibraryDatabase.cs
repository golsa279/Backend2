using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ark.Library.Backend.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ark.Library.Backend.API.Data
{
    public class LibraryDatabase : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public LibraryDatabase(DbContextOptions options)
            :base(options)
        {
            
        }
    }
}