using System.Collections.Generic;
using System.Linq;
using Library.Data;

namespace Library.Logic
{
    public class BooksStateService
    {
        private readonly IBooksStateRepository booksStateRepository;

        public BooksStateService(IBooksStateRepository booksStateRepository)
        {
            this.booksStateRepository = booksStateRepository;
        }

        public List<Book> GetAllAvailableBooks()
        {
            var availableBooks = booksStateRepository.GetAllAvailableBooks().ToList();

            return availableBooks.Count == 0 ? null : availableBooks;
        }

        public int GetAmountOfAvailableBooks(int dictionaryId)
        {
            var amount = booksStateRepository.GetAmountOfAvailableBooksById(dictionaryId);
            return amount;
        }

        public void UpdateBooksAmount(int dictionaryId, int actualBooksAmount)
        {
            booksStateRepository.UpdateBooksAmount(dictionaryId, actualBooksAmount);
        }
    }
}