using System.Collections.Generic;
using System.Linq;

namespace Library.Data
{
    public interface IBooksStateRepository
    {
        IEnumerable<Book> GetAllAvailableBooks();
        int GetAmountOfAvailableBooksById(int dictionaryId);
        int UpdateBooksAmount(int dictionaryId, int actualBooksAmount);
    }
}