using System.Collections.Generic;
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
            var availableBooks = booksStateRepository.GetAllAvailableBooks();

            return availableBooks.Count == 0 ? null : availableBooks;
        }

        public int GetAmountOfAvailableBooks(int id)
        {
            var amount = booksStateRepository.GetAmountOfAvailableBooksById(id);
            return amount;
        }

        public void UpdateBooksAmount(int bookId, int actualBooksAmount)
        {
            booksStateRepository.UpdateBooksAmount(bookId, actualBooksAmount);
        }
    }
}