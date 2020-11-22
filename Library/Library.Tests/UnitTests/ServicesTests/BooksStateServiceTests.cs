using System.Collections.Generic;
using Library.Data;
using Library.Logic;
using Moq;
using Xunit;

namespace Library.LogicTests
{
    public class BooksStateServiceTests
    {
        public BooksStateServiceTests()
        {
            libraryRepositoryMock = new Mock<IBooksStateRepository>();
            booksStateService = new BooksStateService(libraryRepositoryMock.Object);
            _bookState.AllBooks = new BookCatalog
            {
                Books = new List<Book>
                {
                    new Book {Id = 1, Title = "aaaa", BookGenre = BookEnum.Adventure, Author = "Aaaa"},
                    new Book {Id = 2, Title = "bbbb", BookGenre = BookEnum.Roman, Author = "Bbbb"},
                    new Book {Id = 3, Title = "cccc", BookGenre = BookEnum.Document, Author = "Cccc"},
                    new Book {Id = 4, Title = "dddd", BookGenre = BookEnum.Adventure, Author = "Aaaa"},
                    new Book {Id = 5, Title = "eeee", BookGenre = BookEnum.Roman, Author = "Bbbb"},
                    new Book {Id = 6, Title = "ffff", BookGenre = BookEnum.Document, Author = "Cccc"}
                }
            };
        }

        private readonly Mock<IBooksStateRepository> libraryRepositoryMock;
        private readonly BooksStateService booksStateService;
        private readonly BookState _bookState = new BookState();

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
            libraryRepositoryMock.Setup(x => x.GetAllAvailableBooks()).Returns(_bookState.AllBooks.Books);

            //Act
            var returnedBooks = booksStateService.GetAllAvailableBooks();

            //Assert
            Assert.Equal(_bookState.AllBooks.Books, returnedBooks);
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