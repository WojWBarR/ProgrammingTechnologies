using System.Collections.Generic;
using System.Linq;

namespace Library.Data
{
    public interface IBooksCatalogRepository
    {
        void AddBook(Book book);
        void DeleteBook(int id);
        void EditBook(Book book);
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        Book GetBookByType(BookEnum bookType);
    }
}