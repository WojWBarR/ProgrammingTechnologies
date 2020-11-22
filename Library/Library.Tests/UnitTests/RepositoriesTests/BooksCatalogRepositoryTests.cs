using System.Collections.Generic;
using Library.Data;
using Xunit;

namespace Library.DataTests
{
    public class BooksCatalogRepositoryTests
    {
        public BooksCatalogRepositoryTests()
        {
            var dataGenerator = new DataGenerator();
            dataContext = dataGenerator.GenerateData();
            booksCatalogRepository = new BooksCatalogRepository(dataContext);
        }

        private readonly BooksCatalogRepository booksCatalogRepository;
        private readonly DataContext dataContext;

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(6)]
        public void ShouldReturnBookById(int id)
        {
            //Arrange
            var booksCatalog = new BookCatalog
            {
                Books = new List<Book>
                {
                    new Book {Id = 1, Title = "aaaa", BookGenre = BookEnum.Adventure, Author = "Aaaa"},
                    new Book {Id = 3, Title = "cccc", BookGenre = BookEnum.Document, Author = "Bbbb"},
                    new Book {Id = 6, Title = "ffff", BookGenre = BookEnum.Document, Author = "Cccc"}
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
            var booksCatalog = new BookCatalog
            {
                Books = new List<Book>
                {
                    new Book {Id = 1, Title = "aaaa", BookGenre = BookEnum.Adventure, Author = "Aaaa"},
                    new Book {Id = 3, Title = "cccc", BookGenre = BookEnum.Document, Author = "Bbbb"},
                    new Book {Id = 5, Title = "ffff", BookGenre = BookEnum.Roman, Author = "Cccc"}
                }
            };

            //Act
            var returnedBook = booksCatalogRepository.GetBookByType(bookType);

            //Assert
            switch (bookType)
            {
                case BookEnum.Adventure:
                    Assert.Equal(booksCatalog.Books[0].BookGenre, returnedBook.BookGenre);
                    break;
                case BookEnum.Document:
                    Assert.Equal(booksCatalog.Books[1].BookGenre, returnedBook.BookGenre);
                    break;
                case BookEnum.Roman:
                    Assert.Equal(booksCatalog.Books[2].BookGenre, returnedBook.BookGenre);
                    break;
            }
        }

        [Fact]
        public void ShouldAddBook()
        {
            //Arrange
            var booksCatalog = new BookCatalog
            {
                Books = new List<Book>
                    {new Book {Id = 7, Title = "aaaa", BookGenre = BookEnum.Historic, Author = "Aaaa"}}
            };

            //Act
            booksCatalogRepository.AddBook(booksCatalog.Books[0]);
            var books = booksCatalogRepository.GetAllBooks();

            //Assert
            Assert.True(books.Count.Equals(7));
        }

        [Fact]
        public void ShouldDeleteBook()
        {
            //Arrange

            //Act
            booksCatalogRepository.DeleteBook(1);

            var books = booksCatalogRepository.GetAllBooks();

            //Assert
            Assert.True(books.Count.Equals(5));
        }

        [Fact]
        public void ShouldEditBook()
        {
            //Arrange

            var book = new Book { Id = 1, Title = "Zzzz", BookGenre = BookEnum.Historic, Author = "Zzzz" };

            //Act
            booksCatalogRepository.EditBook(book);
            var returnedBook = booksCatalogRepository.GetBookById(1);

            //Assert
            Assert.Equal(book.Id, returnedBook.Id);
            Assert.Equal(book.Title, returnedBook.Title);
            Assert.Equal(book.BookGenre, returnedBook.BookGenre);
            Assert.Equal(book.Author, returnedBook.Author);
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