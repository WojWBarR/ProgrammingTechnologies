using System.Collections.Generic;
using System.Linq;
using Library.Data;

namespace Library.Logic
{
    public class BooksCatalogService
    {
        private readonly LibraryDbContext _dbContext;

        public BooksCatalogService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _dbContext.Set<Book>();
        }

        public Book GetBookById(int id)
        {
            return _dbContext.Set<Book>().FirstOrDefault(i => i.Id.Equals(id));
        }

        public Book GetBookByType(BookEnum bookType)
        {
            return _dbContext.Set<Book>().FirstOrDefault(b => b.BookGenre.Equals(bookType));
        }

        public void DeleteBook(int id)
        {
            var deletedBook = _dbContext.Set<Book>().FirstOrDefault(i => i.Id.Equals(id));

            if (deletedBook != null)
            {
                _dbContext.Set<Book>().Remove(deletedBook);

                _dbContext.SaveChanges();
            }
        }

        public void EditBook(Book book)
        {
            var editedBook = _dbContext.Set<Book>().FirstOrDefault(b => b.Id.Equals(book.Id));

            if (editedBook != null)
            {
                editedBook.Title = book.Title;
                editedBook.BookGenre = book.BookGenre;
                editedBook.Author = book.Author;

                _dbContext.SaveChanges();
            }
        }

        public void AddBook(Book book)
        {
            var addedBook = new Book
            {
                Id = book.Id,
                Title = book.Title,
                BookGenre = book.BookGenre,
                Author = book.Author
            };

            _dbContext.Set<Book>().Add(addedBook);

            _dbContext.SaveChanges();
        }
    }
}