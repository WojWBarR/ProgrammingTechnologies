using Library.Data;
using Xunit;

namespace Library.DataTests
{
    public class RandomDataGeneratorTests
    {
        public RandomDataGeneratorTests()
        {
            randomDataGenerator = new RandomDataGenerator();
        }

        private readonly RandomDataGenerator randomDataGenerator;

        [Fact]
        public void ShouldReturnBookType()
        {
            //Arrange

            //Act
            var returnedBook = randomDataGenerator.CreateRandomBook();

            //Assert
            Assert.IsType<Book>(returnedBook);
        }

        [Fact]
        public void ShouldReturnRentalEventType()
        {
            //Arrange

            //Act
            var randomRentalEvent = randomDataGenerator.CreateRandomRentalEvent();

            //Assert
            Assert.IsType<RentalEvent>(randomRentalEvent);
        }

        [Fact]
        public void ShouldReturnReturnEventType()
        {
            //Arrange

            //Act
            var randomReturnEvent = randomDataGenerator.CreateRandomReturnEvent();

            //Assert
            Assert.IsType<ReturnEvent>(randomReturnEvent);
        }

        [Fact]
        public void ShouldReturnStateType()
        {
            //Arrange

            //Act
            var randomBookState = randomDataGenerator.CreateRandomBookState();

            //Assert
            Assert.IsType<BookState>(randomBookState);
        }

        [Fact]
        public void ShouldReturnUserType()
        {
            //Arrange

            //Act
            var returnedUser = randomDataGenerator.CreateRandomUser();

            //Assert
            Assert.IsType<User>(returnedUser);
        }
    }
}
