using System.Collections.Generic;
using System.Linq;

namespace Library.Data
{
    public class BooksCatalogRepository : IBooksCatalogRepository
    {
        private readonly DataContext _dataContext;

        public BooksCatalogRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Book> GetAllBooks()
        {
            return _dataContext.BookCatalog.Books;
        }

        public Book GetBookById(int id)
        {
            return _dataContext.BookCatalog.Books.FirstOrDefault(i => i.Id.Equals(id));
        }

        public Book GetBookByType(BookEnum bookType)
        {
            return _dataContext.BookCatalog.Books.FirstOrDefault(t => t.BookGenre.Equals(bookType));
        }

        public void DeleteBook(int id)
        {
            var deletedBook = _dataContext.BookCatalog.Books.FirstOrDefault(i => i.Id.Equals(id));

            if (deletedBook != null) _dataContext.BookCatalog.Books.Remove(deletedBook);
        }

        public void EditBook(Book book)
        {
            var editedBook = _dataContext.BookCatalog.Books.FirstOrDefault(b => b.Id.Equals(book.Id));

            if (editedBook != null)
            {
                editedBook.Title = book.Title;
                editedBook.BookGenre = book.BookGenre;
                editedBook.Author = book.Author;
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

            _dataContext.BookCatalog.Books.Add(addedBook);
        }
    }
}