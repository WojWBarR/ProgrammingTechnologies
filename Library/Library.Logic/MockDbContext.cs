using System.Collections.Generic;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic
{
    public class MockDbContext : IMockDbContext
    {
        private readonly BooksCatalog bookCatalog = new BooksCatalog();
        private List<BookEvent> bookEvents;
        private readonly BooksState booksState = new BooksState();
        private List<User> users;

        public List<BookEvent> BookEvents()
        {
            bookEvents = new List<BookEvent>
            {
                new RentalEvent {RentalDate = default, RentalUser = default, BooksInLibrary = default},
                new RentalEvent {RentalDate = default, RentalUser = default, BooksInLibrary = default},
                new ReturnEvent {ReturnDate = default, RentalUser = default}
            };

            return bookEvents;
        }

        public BooksState AvailableBooks()
        {
            booksState.AvailableBooks = new BooksCatalog
            {
                Books = new List<BooksCatalog.Book>
                {
                    new BooksCatalog.Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure},
                    new BooksCatalog.Book {Id = 2, Title = "bbbb", BookType = BookEnum.Roman},
                    new BooksCatalog.Book {Id = 3, Title = "cccc", BookType = BookEnum.Document},
                    new BooksCatalog.Book {Id = 4, Title = "dddd", BookType = BookEnum.Historic},
                    new BooksCatalog.Book {Id = 5, Title = "eeee", BookType = BookEnum.SciFi},
                    new BooksCatalog.Book {Id = 6, Title = "ffff", BookType = BookEnum.Document}
                }
            };

            return booksState;
        }

        public Dictionary<int, int> AvailableBooksAmount()
        {
            booksState.AvailableBooksAmount = new Dictionary<int, int>
            {
                {booksState.AvailableBooks.Books[0].Id, 32},
                {booksState.AvailableBooks.Books[1].Id, 2},
                {booksState.AvailableBooks.Books[2].Id, 18},
                {booksState.AvailableBooks.Books[3].Id, 6},
                {booksState.AvailableBooks.Books[4].Id, 2},
                {booksState.AvailableBooks.Books[5].Id, 40}
            };

            return booksState.AvailableBooksAmount;
        }

        public BooksCatalog BooksCatalog()
        {
            bookCatalog.Books = new List<BooksCatalog.Book>
            {
                new BooksCatalog.Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure},
                new BooksCatalog.Book {Id = 2, Title = "bbbb", BookType = BookEnum.Roman},
                new BooksCatalog.Book {Id = 3, Title = "cccc", BookType = BookEnum.Document},
                new BooksCatalog.Book {Id = 4, Title = "dddd", BookType = BookEnum.Adventure},
                new BooksCatalog.Book {Id = 5, Title = "eeee", BookType = BookEnum.Roman},
                new BooksCatalog.Book {Id = 6, Title = "ffff", BookType = BookEnum.Document}
            };

            return bookCatalog;
        }

        public List<User> Users()
        {
            users = new List<User>
            {
                new User {Id = 1, Name = "aaa", Surname = "aaaa", AmountOfBooksRented = 1},
                new User {Id = 2, Name = "bbb", Surname = "bbb", AmountOfBooksRented = 4},
                new User {Id = 3, Name = "ccc", Surname = "ccc", AmountOfBooksRented = 3},
                new User {Id = 4, Name = "ddd", Surname = "ddd", AmountOfBooksRented = 1},
                new User {Id = 5, Name = "eee", Surname = "eee", AmountOfBooksRented = 4},
                new User {Id = 6, Name = "fff", Surname = "fff", AmountOfBooksRented = 6}
            };

            return users;
        }
    }
}