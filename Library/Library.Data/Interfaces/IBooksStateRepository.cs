using System.Collections.Generic;

namespace Library.Data
{
    public interface IBooksStateRepository
    {
        List<Book> GetAllAvailableBooks();
        int GetAmountOfAvailableBooksById(int id);
        int UpdateBooksAmount(int bookId, int actualBooksAmount);
    }
}