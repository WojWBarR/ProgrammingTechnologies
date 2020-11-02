using System;
using System.Collections.Generic;
using System.Text;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface ILibraryRepository
    {
        List<Book> GetAllAvailableBooks();
        List<Book> GetAllUnavailableBooks();
        void AddBookWithChangedState(Book book);
    }
}
