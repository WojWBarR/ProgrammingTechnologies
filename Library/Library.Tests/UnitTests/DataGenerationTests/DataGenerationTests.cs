using Library.Data;
using Xunit;

namespace Library.DataTests
{
    public class DataGeneratorTests
    {
        public DataGeneratorTests()
        {
            dataGenerator = new DataGenerator();
            dataContext = dataGenerator.GenerateData();
        }

        private readonly DataContext dataContext;
        private readonly DataGenerator dataGenerator;

        [Fact]
        public void ShouldReturnProperAmountOfBooksFromCatalog()
        {
            //Arrange

            //Act
            var returnedBooks = dataContext.BookCatalog.Books;

            //Assert
            Assert.True(returnedBooks.Count.Equals(6));
        }

        [Fact]
        public void ShouldReturnProperAmountOfBooksFromState()
        {
            //Arrange

            //Act
            var returnedBooks = dataContext.BookState.AllBooks;

            //Assert
            Assert.True(returnedBooks.Books.Count.Equals(6));
        }

        [Fact]
        public void ShouldReturnProperAmountOfEvents()
        {
            //Arrange

            //Act
            var returnedEvents = dataContext.BookEvents;

            //Assert
            Assert.True(returnedEvents.Count.Equals(5));
        }

        [Fact]
        public void ShouldReturnProperAmountOfUsers()
        {
            //Arrange

            //Act
            var returnedUsers = dataContext.Users;

            //Assert
            Assert.True(returnedUsers.Count.Equals(6));
        }
    }
}
