using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Services
{
    public class BookEventService
    {
        private readonly BooksState availableLibraryBooks = new BooksState();
        private readonly IBookEventRepository bookEventRepository;
        private readonly BooksCatalog booksCatalog;
        private readonly IBooksCatalogRepository booksCatalogRepository;
        private readonly IBooksStateRepository booksStateRepository;
        private readonly IUserRepository userRepository;

        public BookEventService(IBookEventRepository bookEventRepository, IBooksStateRepository booksStateRepository,
            IUserRepository userRepository, IBooksCatalogRepository booksCatalogRepository)
        {
            this.bookEventRepository = bookEventRepository;
            this.booksStateRepository = booksStateRepository;
            this.userRepository = userRepository;
            this.booksCatalogRepository = booksCatalogRepository;
        }

        public List<BookEvent> GetAllBookEvents()
        {
            var rentals = bookEventRepository.GetAllBookEvents();

            return rentals.Count == 0 ? null : rentals;
        }

        public RentalEvent RentBook(int userId, int bookId, DateTime rentalDate)
        {
            var availableAmountOfParticularBook = booksStateRepository.GetAmountOfAvailableBooksById(bookId);

            if (availableAmountOfParticularBook <= 0) return null;

            var rentalUser = userRepository.GetUserById(userId);
            availableLibraryBooks.AvailableBooks = new BooksCatalog
            {
                Books = booksStateRepository.GetAllAvailableBooks()
            };

            var rental = InitializeEvent(rentalDate, rentalUser, availableLibraryBooks, bookId, out var book);

            if (ValidateData(rentalUser, book, rentalDate))
            {
                OnUserRent(rentalUser, true);

                OnBookRent(book.Id, --availableAmountOfParticularBook);

                bookEventRepository.AddRentalEvent(rental);

                return rental;
            }

            return null;
        }

        public ReturnEvent ReturnBook(int userId, int bookId, DateTime returnDate)
        {
            var availableAmountOfParticularBook = booksStateRepository.GetAmountOfAvailableBooksById(bookId);
            var rentalUser = userRepository.GetUserById(userId);
            var returnedBook = booksCatalogRepository.GetBookById(bookId);

            if (ValidateData(rentalUser, returnedBook, returnDate))
            {
                OnUserRent(rentalUser, false);

                OnBookRent(returnedBook.Id, ++availableAmountOfParticularBook);

                var returnEvent = new ReturnEvent
                {
                    RentalUser = rentalUser,
                    ReturnDate = returnDate
                };

                bookEventRepository.AddReturnEvent(returnEvent);

                return returnEvent;
            }

            return null;
        }

        private RentalEvent InitializeEvent(DateTime rentalDate, User rentalUser, BooksState booksState, int bookId,
            out BooksCatalog.Book book)
        {
            book = booksState.AvailableBooks.Books.FirstOrDefault(i => i.Id.Equals(bookId));

            return new RentalEvent
            {
                RentalDate = rentalDate,
                RentalUser = rentalUser,
                BooksInLibrary = booksState
            };
        }

        private void OnBookRent(int bookId, int amountOfBooks)
        {
            booksStateRepository.UpdateBooksAmount(bookId, amountOfBooks);
        }

        private void OnUserRent(User rentalUser, bool isRenting)
        {
            if (isRenting)
                rentalUser.AmountOfBooksRented++;
            else
                rentalUser.AmountOfBooksRented--;
        }

        private bool ValidateData(User user, BooksCatalog.Book book, DateTime date)
        {
            if (user.Equals(null) || book.Equals(null) || date.Equals(null)) return false;

            return true;
        }
    }
}