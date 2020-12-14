using System.Collections.Generic;
using Library.Data;
using Library.Logic;
using Moq;
using Xunit;

namespace Library.LogicTests
{
    public class BooksCatalogServiceTests
    {
        public BooksCatalogServiceTests()
        {
            bookRepositoryMock = new Mock<IBooksCatalogRepository>();
            bookService = new BooksCatalogService(bookRepositoryMock.Object);
            _bookCatalog.Books = new List<Book>
            {
                new Book {Id = 1, Title = "aaaa", BookGenre = BookEnum.Adventure, Author = "Aaaa"},
                new Book {Id = 2, Title = "bbbb", BookGenre = BookEnum.Roman, Author = "Bbbb"},
                new Book {Id = 3, Title = "cccc", BookGenre = BookEnum.Document, Author = "Cccc"},
                new Book {Id = 4, Title = "dddd", BookGenre = BookEnum.Adventure, Author = "Aaaa"},
                new Book {Id = 5, Title = "eeee", BookGenre = BookEnum.Roman, Author = "Bbbb"},
                new Book {Id = 6, Title = "ffff", BookGenre = BookEnum.Document, Author = "Cccc"}
            };
        }

        private readonly Mock<IBooksCatalogRepository> bookRepositoryMock;
        private readonly BooksCatalogService bookService;
        private readonly Book book = new Book();
        private readonly BookCatalog _bookCatalog = new BookCatalog();

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(default)]
        public void ShouldGetBookById(int id)
        {
            //Arrange
            bookRepositoryMock.Setup(x => x.GetBookById(It.IsAny<int>())).Returns(book);

            //Act
            var returnedBook = bookService.GetBook(id);

            //Assert
            Assert.Equal(book, returnedBook);
        }

        [Theory]
        [InlineData(BookEnum.Adventure)]
        [InlineData(BookEnum.Document)]
        [InlineData(BookEnum.Roman)]
        [InlineData(default)]
        public void ShouldReturnBookByBookType(BookEnum bookType)
        {
            //Arrange
            bookRepositoryMock.Setup(x => x.GetBookByType(It.IsAny<BookEnum>())).Returns(book);

            //Act
            var returnedBook = bookService.GetBook(bookType);

            //Assert
            Assert.Equal(book, returnedBook);
        }

        [Fact]
        public void ShouldAddBook()
        {
            //Arrange
            bookRepositoryMock.Setup(x => x.AddBook(It.IsAny<Book>()));

            //Act
            bookService.AddBook(default);

            //Assert
        }

        [Fact]
        public void ShouldDeleteBook()
        {
            //Arrange
            bookRepositoryMock.Setup(x => x.DeleteBook(It.IsAny<int>()));

            //Act
            bookService.DeleteBook(default);

            //Assert
        }

        [Fact]
        public void ShouldEditBook()
        {
            //Arrange
            bookRepositoryMock.Setup(x => x.EditBook(It.IsAny<Book>()));


            //Act
            bookService.EditBook(default);

            //Assert
        }

        [Fact]
        public void ShouldGetAllBooks()
        {
            //Arrange
            //bookRepositoryMock.Setup(x => x.GetAllBooks()).Returns(_bookCatalog.Books);

            //Act
            var resultedBooks = bookService.GetAllBooks();

            //Assert
            Assert.Equal(_bookCatalog.Books, resultedBooks);
        }
    }
}