using System.Collections.Generic;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IBooksCatalogRepository
    {
        void AddBook(BooksCatalog.Book book);
        void DeleteBook(int id);
        void EditBook(BooksCatalog.Book book);
        List<BooksCatalog.Book> GetAllBooks();
        BooksCatalog.Book GetBookById(int id);
        BooksCatalog.Book GetBookByType(BookEnum bookType);
    }
}
