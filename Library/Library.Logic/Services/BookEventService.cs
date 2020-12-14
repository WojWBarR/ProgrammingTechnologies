using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;

namespace Library.Logic
{
    public class BookEventService
    {
        private readonly BookState availableLibraryBook = new BookState();
        private readonly IBookEventRepository bookEventRepository;
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

        public IEnumerable<BookEvent> GetAllRentals()
        {
            var rentalEvents = bookEventRepository.GetAllBookRentalEvents().ToList();

            return rentalEvents.Count == 0 ? null : rentalEvents;
        }

        public IEnumerable<BookEvent> GetAllReturns()
        {
            var returnEvents = bookEventRepository.GetAllBookReturnEvents().ToList();

            return returnEvents.Count == 0 ? null : returnEvents;
        }

        public RentalEvent RentBook(int userId, int bookId, DateTime rentalDate)
        {
            var availableAmountOfParticularBook = booksStateRepository.GetAmountOfAvailableBooksById(bookId);

            if (availableAmountOfParticularBook <= 0) return null;

            var rentalUser = userRepository.GetUserById(userId);
            availableLibraryBook.AllBooks = new BookCatalog
            {
                Books = booksStateRepository.GetAllAvailableBooks().ToList()
            };

            var rental = InitializeEvent(rentalDate, rentalUser, availableLibraryBook, bookId, out var book);

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
                    EventDate = returnDate
                };

                bookEventRepository.AddReturnEvent(returnEvent);

                return returnEvent;
            }

            return null;
        }

        private RentalEvent InitializeEvent(DateTime rentalDate, User rentalUser, BookState bookState, int bookId,
            out Book book)
        {
            book = bookState.AllBooks.Books.FirstOrDefault(i => i.Id.Equals(bookId));

            return new RentalEvent
            {
                EventDate = rentalDate,
                RentalUser = rentalUser,
                BookInLibrary = bookState
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

        private bool ValidateData(User user, Book book, DateTime date)
        {
            if (user.Equals(null) || book.Equals(null) || date.Equals(null)) return false;

            return true;
        }
    }
}