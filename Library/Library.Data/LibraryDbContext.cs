using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext : DbContext
    {
        virtual public DbSet<BookCatalog> BookCatalogs { get; set; }

        virtual public DbSet<Book> Books { get; set; }
        virtual public DbSet<BookState> BookStates { get; set; }
        virtual public DbSet<RentalEvent> RentalEvents { get; set; }
        virtual public DbSet<ReturnEvent> ReturnEvents { get; set; }
        virtual public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=MSI\\BARTEKSQL;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }
    }
}