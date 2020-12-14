using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI\\BARTEKSQL;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookCatalog> BookCatalogs { get; set; }
        public DbSet<BookState> BookStates { get; set; }
        public DbSet<RentalEvent> RentalEvents { get; set; }
        public DbSet<ReturnEvent> ReturnEvents { get; set; }
    }
}