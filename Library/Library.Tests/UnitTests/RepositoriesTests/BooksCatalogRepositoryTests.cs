using System.Collections.Generic;
using Library.Data;
using Library.Data.Models;
using Library.Logic;
using Library.Logic.Repositories;
using Xunit;

namespace Library.Tests.UnitTests.RepositoriesTests
{
    public class BooksCatalogRepositoryTests
    {
        public BooksCatalogRepositoryTests()
        {
            dbContext = new MockDbContext();
            booksCatalogRepository = new MockBooksCatalogRepository(dbContext);
        }

        private readonly MockBooksCatalogRepository booksCatalogRepository;
        private readonly MockDbContext dbContext;

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(6)]
        public void ShouldReturnBookById(int id)
        {
            //Arrange
            var booksCatalog = new BooksCatalog
            {
                Books = new List<BooksCatalog.Book>
                {
                    new BooksCatalog.Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure},
                    new BooksCatalog.Book {Id = 3, Title = "cccc", BookType = BookEnum.Document},
                    new BooksCatalog.Book {Id = 6, Title = "ffff", BookType = BookEnum.Document}
                }
            };

            //Act
            var returnedBook = booksCatalogRepository.GetBookById(id);

            //Assert
            switch (id)
            {
                case 1:
                    Assert.Equal(booksCatalog.Books[0].Id, returnedBook.Id);
                    break;
                case 3:
                    Assert.Equal(booksCatalog.Books[1].Id, returnedBook.Id);
                    break;
                case 6:
                    Assert.Equal(booksCatalog.Books[2].Id, returnedBook.Id);
                    break;
            }
        }

        [Theory]
        [InlineData(BookEnum.Adventure)]
        [InlineData(BookEnum.Document)]
        [InlineData(BookEnum.Roman)]
        public void ShouldReturnBookByBookType(BookEnum bookType)
        {
            //Arrange
            var booksCatalog = new BooksCatalog
            {
                Books = new List<BooksCatalog.Book>
                {
                    new BooksCatalog.Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure},
                    new BooksCatalog.Book {Id = 3, Title = "cccc", BookType = BookEnum.Document},
                    new BooksCatalog.Book {Id = 5, Title = "ffff", BookType = BookEnum.Roman}
                }
            };

            //Act
            var returnedBook = booksCatalogRepository.GetBookByType(bookType);

            //Assert
            switch (bookType)
            {
                case BookEnum.Adventure:
                    Assert.Equal(booksCatalog.Books[0].BookType, returnedBook.BookType);
                    break;
                case BookEnum.Document:
                    Assert.Equal(booksCatalog.Books[1].BookType, returnedBook.BookType);
                    break;
                case BookEnum.Roman:
                    Assert.Equal(booksCatalog.Books[2].BookType, returnedBook.BookType);
                    break;
            }
        }

        [Fact]
        public void ShouldAddBook()
        {
            //Arrange
            var booksCatalog = new BooksCatalog
            {
                Books = new List<BooksCatalog.Book>
                    {new BooksCatalog.Book {Id = 7, Title = "aaaa", BookType = BookEnum.Historic}}
            };

            //Act
            booksCatalogRepository.AddBook(booksCatalog.Books[0]);

            //Assert
        }

        [Fact]
        public void ShouldDeleteBook()
        {
            //Arrange

            //Act
            booksCatalogRepository.DeleteBook(1);

            var books = booksCatalogRepository.GetAllBooks();

            //Assert
        }

        [Fact]
        public void ShouldEditBook()
        {
            //Arrange
            var booksCatalog = new BooksCatalog
            {
                Books = new List<BooksCatalog.Book>
                    {new BooksCatalog.Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure}}
            };

            //Act
            booksCatalogRepository.EditBook(booksCatalog.Books[0]);

            //Assert
        }

        [Fact]
        public void ShouldReturnAllBooks()
        {
            //Arrange

            //Act
            var returnedBooks = booksCatalogRepository.GetAllBooks();

            //Assert
            Assert.True(returnedBooks.Count.Equals(6));
        }
    }
}
