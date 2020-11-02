using System;
using System.Collections.Generic;
using System.Text;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        Book GetBookByType(BookEnum bookType);
        void DeleteBook(int id);
        void EditBook(Book book);
        void AddBook(Book book);
    }
}
