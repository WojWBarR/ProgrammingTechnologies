﻿using System.Collections.Generic;
using Library.Data.Models;
using Library.Logic;
using Library.Logic.Repositories;
using Xunit;

namespace Library.Tests.UnitTests.RepositoriesTests
{
    public class UserRepositoryTests
    {
        public UserRepositoryTests()
        {
            dbContext = new MockDbContext();
            userRepository = new MockUserRepository(dbContext);
        }

        private readonly MockUserRepository userRepository;
        private readonly MockDbContext dbContext;

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(6)]
        public void ShouldReturnUserById(int id)
        {
            //Arrange
            var expectedUsers = new List<User>
            {
                new User {Id = 1, Name = "aaa", Surname = "aaaa", AmountOfBooksRented = 1},
                new User {Id = 3, Name = "ccc", Surname = "ccc", AmountOfBooksRented = 3},
                new User {Id = 6, Name = "fff", Surname = "fff", AmountOfBooksRented = 6}
            };

            //Act
            var returnedUser = userRepository.GetUserById(id);

            //Assert
            switch (id)
            {
                case 1:
                    Assert.Equal(expectedUsers[0].Id, returnedUser.Id);
                    break;
                case 3:
                    Assert.Equal(expectedUsers[1].Id, returnedUser.Id);
                    break;
                case 6:
                    Assert.Equal(expectedUsers[2].Id, returnedUser.Id);
                    break;
            }
        }

        [Fact]
        public void ShouldAddUser()
        {
            //Arrange
            var newUser = new User
            {
                Id = 7,
                Name = "fff",
                Surname = "fff",
                AmountOfBooksRented = 30
            };

            //Act
            userRepository.AddUser(newUser);

            //Assert
        }

        [Fact]
        public void ShouldDeleteUser()
        {
            //Arrange

            //Act
            userRepository.DeleteUser(1);

            //Assert
        }

        [Fact]
        public void ShouldEditUser()
        {
            //Arrange
            var expectedUser = new User
            {
                Id = 1,
                Name = "fff",
                Surname = "fff",
                AmountOfBooksRented = 30
            };

            //Act
            userRepository.EditUser(expectedUser);

            //Assert
        }

        [Fact]
        public void ShouldReturnAllUsers()
        {
            //Arrange

            //Act
            var returnedUsers = userRepository.GetAllUsers();

            //Assert
            Assert.True(returnedUsers.Count.Equals(6));
        }
    }
}