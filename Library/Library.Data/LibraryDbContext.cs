using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext : DbContext
    {
        public virtual DbSet<BookCatalog> BookCatalogs { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookState> BookStates { get; set; }
        public virtual DbSet<RentalEvent> RentalEvents { get; set; }
        public virtual DbSet<ReturnEvent> ReturnEvents { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}