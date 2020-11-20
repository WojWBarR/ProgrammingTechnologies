using System.Collections.Generic;

namespace Library.Data
{
    public interface IBooksCatalogRepository
    {
        void AddBook(Book book);
        void DeleteBook(int id);
        void EditBook(Book book);
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        Book GetBookByType(BookEnum bookType);
    }
}