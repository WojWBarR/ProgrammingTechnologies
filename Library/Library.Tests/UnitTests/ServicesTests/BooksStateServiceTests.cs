using System.Collections.Generic;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;
using Library.Logic.Services;
using Moq;
using Xunit;

namespace Library.Tests.UnitTests.ServicesTests
{
    public class BooksStateServiceTests
    {
        public BooksStateServiceTests()
        {
            libraryRepositoryMock = new Mock<IBooksStateRepository>();
            booksStateService = new BooksStateService(libraryRepositoryMock.Object);
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
        }

        private readonly Mock<IBooksStateRepository> libraryRepositoryMock;
        private readonly BooksStateService booksStateService;
        private readonly BooksState booksState = new BooksState();

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(default)]
        public void ShouldGetAmountOfAvailableBooksById(int id)
        {
            //Arrange
            int expectedAmountOfBooks = default;
            libraryRepositoryMock.Setup(x => x.GetAmountOfAvailableBooksById(It.IsAny<int>()))
                .Returns(expectedAmountOfBooks);

            //Act
            var resultedAmountOfBooks = booksStateService.GetAmountOfAvailableBooks(id);

            //Assert
            Assert.Equal(expectedAmountOfBooks, resultedAmountOfBooks);
        }

        [Fact]
        public void ShouldReturnAllAvailableBooks()
        {
            //Arrange
            libraryRepositoryMock.Setup(x => x.GetAllAvailableBooks()).Returns(booksState.AvailableBooks.Books);

            //Act
            var returnedBooks = booksStateService.GetAllAvailableBooks();

            //Assert
            Assert.Equal(booksState.AvailableBooks.Books, returnedBooks);
            Assert.True(returnedBooks.Count.Equals(6));
        }

        [Fact]
        public void ShouldUpdateBookWithProperlyChangedState()
        {
            //Arrange
            libraryRepositoryMock.Setup(x => x.UpdateBooksAmount(It.IsAny<int>(), It.IsAny<int>()));

            //Act
            booksStateService.UpdateBooksAmount(default, default);

            //Assert
        }
    }
}