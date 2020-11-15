using System;
using System.Collections.Generic;
using Library.Data.Models;
using System.Text;

namespace Library.Data.Interfaces
{
    public interface IMockDbContext
    {

        Dictionary<int, int> AvailableBooksAmount();
        List<BookEvent> BookEvents();
        BooksCatalog BooksCatalog();
        BooksState AvailableBooks();
        List<User> Users();
    }
}
