using System;
using System.Collections.Generic;
using System.Text;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IBooksStateRepository
    {
        List<BooksCatalog.Book> GetAllAvailableBooks();
        int GetAmountOfAvailableBooksById(int id);
        int UpdateBooksAmount(int bookId, int actualBooksAmount);
    }
}
