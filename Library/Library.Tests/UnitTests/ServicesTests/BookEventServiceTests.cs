﻿using System;
using System.Collections.Generic;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;
using Library.Logic.Services;
using Moq;
using Xunit;

namespace Library.Tests.UnitTests.ServicesTests
{
    public class BookEventServiceTests
    {
        public BookEventServiceTests()
        {
            bookEventRepositoryMock = new Mock<IBookEventRepository>();
            bookStateRepositoryMock = new Mock<IBooksStateRepository>();
            userRepositoryMock = new Mock<IUserRepository>();
            booksCatalogRepositoryMock = new Mock<IBooksCatalogRepository>();

            bookEventService = new BookEventService(bookEventRepositoryMock.Object, bookStateRepositoryMock.Object,
                userRepositoryMock.Object, booksCatalogRepositoryMock.Object);

            bookEvents = new List<BookEvent>
            {
                new RentalEvent {RentalDate = default, RentalUser = default, BooksInLibrary = default},
                new RentalEvent {RentalDate = default, RentalUser = default, BooksInLibrary = default},
                new ReturnEvent {ReturnDate = default, RentalUser = default}
            };

            booksState.AvailableBooks = new BooksCatalog
            {
                Books = new List<BooksCatalog.Book>
                {
                    new BooksCatalog.Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure},
                    new BooksCatalog.Book {Id = 2, Title = "bbbb", BookType = BookEnum.Roman},
                    new BooksCatalog.Book {Id = 3, Title = "cccc", BookType = BookEnum.Document},
                    new BooksCatalog.Book {Id = 4, Title = "dddd", BookType = BookEnum.Adventure},
                    new BooksCatalog.Book {Id = 5, Title = "eeee", BookType = BookEnum.Roman},
                    new BooksCatalog.Book {Id = 6, Title = "ffff", BookType = BookEnum.Document}
                }
            };

            rentalUser = new User
            {
                Id = 1,
                Name = "naaa",
                Surname = "saaa",
                AmountOfBooksRented = 0
            };

            returnedUser = new User
            {
                Id = 2,
                Name = "naaa",
                Surname = "saaa",
                AmountOfBooksRented = 13
            };

            availableAmountOfParticularBook = random.Next();

            bookStateRepositoryMock.Setup(x => x.GetAmountOfAvailableBooksById(It.IsAny<int>()))
                .Returns(availableAmountOfParticularBook);
            bookStateRepositoryMock.Setup(x => x.GetAllAvailableBooks()).Returns(booksState.AvailableBooks.Books);
        }

        private readonly Mock<IBookEventRepository> bookEventRepositoryMock;
        private readonly Mock<IBooksStateRepository> bookStateRepositoryMock;
        private readonly Mock<IUserRepository> userRepositoryMock;
        private readonly Mock<IBooksCatalogRepository> booksCatalogRepositoryMock;
        private readonly BookEventService bookEventService;
        private readonly List<BookEvent> bookEvents;
        private readonly User rentalUser;
        private readonly User returnedUser;
        private readonly BookState booksState = new BookState();
        private readonly Random random = new Random();
        private int availableAmountOfParticularBook;

        [Fact]
        public void ShouldCreateNewRental()
        {
            //Arrange
            var rentDate = new DateTime(2020, 11, 13);
            var expectedAmountOfAvailableBooks = availableAmountOfParticularBook - 1;
            var expectedRentalEvent = new RentalEvent
            {
                RentalUser = rentalUser,
                BooksInLibrary = booksState,
                RentalDate = rentDate
            };

            userRepositoryMock.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(rentalUser);
            bookStateRepositoryMock.Setup(x => x.UpdateBooksAmount(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(--availableAmountOfParticularBook);

            //Act
            var resultedRentalEvent =
                bookEventService.RentBook(rentalUser.Id, booksState.AvailableBooks.Books[0].Id, rentDate);

            //Assert
            Assert.Equal(1, rentalUser.AmountOfBooksRented);
            Assert.Equal(expectedAmountOfAvailableBooks, availableAmountOfParticularBook);
            Assert.Equal(expectedRentalEvent.ToString(), resultedRentalEvent.ToString());
        }

        [Fact]
        public void ShouldGetAllBookEvents()
        {
            //Arrange
            bookEventRepositoryMock.Setup(x => x.GetAllBookEvents()).Returns(bookEvents);

            //Act
            var resultedBookEvents = bookEventService.GetAllBookEvents();

            //Assert
            Assert.Equal(resultedBookEvents, bookEvents);
        }

        [Fact]
        public void ShouldSuccessfullyGiveBookBack()
        {
            //Arrange
            var returnDate = new DateTime(2020, 11, 17);
            var expectedAmountOfAvailableBooks = availableAmountOfParticularBook + 1;
            var expectedReturnEvent = new ReturnEvent
            {
                RentalUser = returnedUser,
                ReturnDate = returnDate
            };

            userRepositoryMock.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(returnedUser);
            bookStateRepositoryMock.Setup(x => x.UpdateBooksAmount(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(++availableAmountOfParticularBook);
            booksCatalogRepositoryMock.Setup(x => x.GetBookById(It.IsAny<int>()))
                .Returns(booksState.AvailableBooks.Books[0]);

            //Act
            var resultedRentedEvent =
                bookEventService.ReturnBook(returnedUser.Id, booksState.AvailableBooks.Books[0].Id, returnDate);

            //Assert
            Assert.Equal(12, returnedUser.AmountOfBooksRented);
            Assert.Equal(expectedAmountOfAvailableBooks, availableAmountOfParticularBook);
            Assert.Equal(expectedReturnEvent.ToString(), resultedRentedEvent.ToString());
        }
    }
}