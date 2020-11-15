using System;
using System.Collections.Generic;
using System.Text;
using Library.Data.Models;
using Library.Logic.Repositories;
using Xunit;

namespace Library.Tests.UnitTests.RepositoriesTests
{
    public class RentalRepositoryTests
    {
        private readonly MockBooksStateRepository rentalRepository;

        public RentalRepositoryTests()
        {
            rentalRepository = new MockBooksStateRepository();
        }

        [Fact]
        public void ShouldReturnAllRentals()
        {
            //Arrange

            //Act
            var returnedRentals = rentalRepository.GetAllRentals();

            //Assert
            Assert.True(returnedRentals.Count.Equals(3));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ShouldReturnRentalId(int id)
        {
            //Arrange
            List<Rental> expectedRentals = new List<Rental>
            {
                new Rental { Id = 1, RentalDate = default, GiveBackDate = default, RentalUser = default, LibraryBooks = default },
                new Rental { Id = 2, RentalDate = default, GiveBackDate = default, RentalUser = default, LibraryBooks = default },
                new Rental { Id = 3, RentalDate = default, GiveBackDate = default, RentalUser = default, LibraryBooks = default }
            };

            //Act
            var returnedRental = rentalRepository.GetRentalById(id);

            //Assert
            switch (id)
            {
                case 1:
                    Assert.Equal(expectedRentals[0].Id, returnedRental.Id);
                    break;
                case 2:
                    Assert.Equal(expectedRentals[1].Id, returnedRental.Id);
                    break;
                case 3:
                    Assert.Equal(expectedRentals[2].Id, returnedRental.Id);
                    break;
            }
        }

        [Fact]
        public void ShouldDeleteRental()
        {
            //Arrange

            //Act
            rentalRepository.DeleteRental(1);

            var rentals = rentalRepository.GetAllRentals();

            //Assert
            Assert.True(rentals.Count.Equals(2));
        }

        [Fact]
        public void ShouldEditRental()
        {
            //Arrange
            Rental expectedRental = new Rental
            {
                Id = 1,
                RentalDate = new DateTime(2020, 11, 03),
                GiveBackDate = new DateTime(2020, 11, 04)
            };

            //Act
            rentalRepository.EditRental(expectedRental);

            var rental = rentalRepository.GetRentalById(expectedRental.Id);

            //Assert
            Assert.Equal(expectedRental.Id, rental.Id);
            Assert.Equal(expectedRental.RentalDate, rental.RentalDate);
            Assert.Equal(expectedRental.GiveBackDate, rental.GiveBackDate);
        }

        [Fact]
        public void ShouldAddRental()
        {
            //Arrange
            Rental newRental = new Rental
            {
                Id = 4,
                RentalDate = new DateTime(2020, 11, 03),
                GiveBackDate = new DateTime(2020, 11, 04)
            };

            //Act
            rentalRepository.AddRental(newRental);

            var books = rentalRepository.GetAllRentals();

            //Assert
            Assert.True(books.Count.Equals(4));
        }
    }
}
