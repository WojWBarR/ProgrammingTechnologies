using Library.Data;
using Xunit;

namespace Library.DataTests
{
    public class BookEventRepositoryTests
    {
        public BookEventRepositoryTests()
        {
            var dataGenerator = new DataGenerator();
            dataContext = dataGenerator.GenerateData();
            bookEventRepository = new BookEventRepository(dataContext);
        }

        private readonly BookEventRepository bookEventRepository;
        private readonly DataContext dataContext;

        [Fact]
        public void ShouldAddRentalEvent()
        {
            //Arrange
            var rentalEvent = new RentalEvent();

            //Act
            bookEventRepository.AddRentalEvent(rentalEvent);
            var returnedBookEvents = bookEventRepository.GetAllBookEvents();

            //Assert
            Assert.True(returnedBookEvents.Count.Equals(6));
        }

        [Fact]
        public void ShouldAddReturnEvent()
        {
            //Arrange
            var returnEvent = new ReturnEvent();

            //Act
            bookEventRepository.AddReturnEvent(returnEvent);
            var returnedBookEvents = bookEventRepository.GetAllBookEvents();

            //Assert
            Assert.True(returnedBookEvents.Count.Equals(6));
        }

        [Fact]
        public void ShouldReturnAllEvents()
        {
            //Arrange

            //Act
            var returnedRentals = bookEventRepository.GetAllBookEvents();

            //Assert
            Assert.True(returnedRentals.Count.Equals(5));
        }
    }
}