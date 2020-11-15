using System.Collections.Generic;
using System.Linq;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class MockBooksStateRepository : IBooksStateRepository
    {
        private readonly MockDbContext dbContext;

        public MockBooksStateRepository(MockDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<BooksCatalog.Book> GetAllAvailableBooks()
        {
            return dbContext.AvailableBooks().AvailableBooks.Books;
        }

        public int GetAmountOfAvailableBooksById(int id)
        {
            var book = dbContext.AvailableBooks().AvailableBooks.Books.FirstOrDefault(i => i.Id.Equals(id));

            if (book != null && dbContext.AvailableBooksAmount().ContainsKey(book.Id))
            {
                var amount = dbContext.AvailableBooksAmount()[book.Id];

                return amount > 0 ? amount : default;
            }

            return default;
        }

        public int UpdateBooksAmount(int bookId, int actualBooksAmount)
        {
            var updatedBook = dbContext.AvailableBooks().AvailableBooks.Books.FirstOrDefault(i => i.Id.Equals(bookId));

            if (dbContext.AvailableBooksAmount().ContainsKey(updatedBook.Id))
                dbContext.AvailableBooksAmount()[updatedBook.Id] = actualBooksAmount;

            return actualBooksAmount;
        }
    }
}