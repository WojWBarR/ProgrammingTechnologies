using Library.Data;
using Library.Data.Models;
using Library.Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Library.Tests.UnitTests.RepositoriesTests
{
    public class BookRepositoryTests
    {
        private readonly MockBookEventRepository bookRepository;

        public BookRepositoryTests()
        {
            bookRepository = new MockBookEventRepository();
        }

        [Fact]
        public void ShouldReturnAllBooks()
        {
            //Arrange

            //Act
            var returnedBooks = bookRepository.GetAllBooks();

            //Assert
            Assert.True(returnedBooks.Count.Equals(6));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(6)]
        public void ShouldReturnBookById(int id)
        {
            //Arrange
            List<Book> expectedBooks = new List<Book>
            {
                new Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure, IsAvailable = true},
                new Book {Id = 3, Title = "cccc", BookType = BookEnum.Document, IsAvailable = false},
                new Book {Id = 6, Title = "ffff", BookType = BookEnum.Document, IsAvailable = false}
            };

            //Act
            var returnedBook = bookRepository.GetBookById(id);

            //Assert
            switch (id)
            {
                case 1:
                    Assert.Equal(expectedBooks[0].Id, returnedBook.Id);
                    break;
                case 3:
                    Assert.Equal(expectedBooks[1].Id, returnedBook.Id);
                    break;
                case 6:
                    Assert.Equal(expectedBooks[2].Id, returnedBook.Id);
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
            List<Book> expectedBooks = new List<Book>
            {
                new Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure, IsAvailable = true},
                new Book {Id = 3, Title = "cccc", BookType = BookEnum.Document, IsAvailable = false},
                new Book {Id = 5, Title = "eeee", BookType = BookEnum.Roman, IsAvailable = false}
            };

            //Act
            var returnedBook = bookRepository.GetBookByType(bookType);

            //Assert
            switch (bookType)
            {
                case BookEnum.Adventure:
                    Assert.Equal(expectedBooks[0].BookType, returnedBook.BookType);
                    break;
                case BookEnum.Document:
                    Assert.Equal(expectedBooks[1].BookType, returnedBook.BookType);
                    break;
                case BookEnum.Roman:
                    Assert.Equal(expectedBooks[2].BookType, returnedBook.BookType);
                    break;
            }
        }

        [Fact]
        public void ShouldDeleteBook()
        {
            //Arrange

            //Act
            bookRepository.DeleteBook(1);

            var books = bookRepository.GetAllBooks();

            //Assert
            Assert.True(books.Count.Equals(5));
        }

        [Fact]
        public void ShouldEditBook()
        {
            //Arrange
            Book expectedBook = new Book
            {
                Id = 1,
                BookType = BookEnum.Historic,
                IsAvailable = false
            };

            //Act
            bookRepository.EditBook(expectedBook);

            var book = bookRepository.GetBookById(expectedBook.Id);

            //Assert
            Assert.Equal(expectedBook.Id, book.Id);
            Assert.Equal(expectedBook.BookType, book.BookType);
            Assert.Equal(expectedBook.IsAvailable, book.IsAvailable);
        }

        [Fact]
        public void ShouldAddBook()
        {
            //Arrange
            Book newBook = new Book
            {
                Id = 7,
                BookType = BookEnum.Historic,
                IsAvailable = false
            };

            //Act
            bookRepository.AddBook(newBook);

            var books = bookRepository.GetAllBooks();

            //Assert
            Assert.True(books.Count.Equals(7));
        }
    }
}
