using System.Collections.Generic;
using Library.Data.Interfaces;
using Library.Data.Models;
using Library.Logic.Services;
using Moq;
using Xunit;

namespace Library.Tests.UnitTests.ServicesTests
{
    public class UserServiceTests
    {
        public UserServiceTests()
        {
            userRepositoryMock = new Mock<IUserRepository>();
            userService = new UserService(userRepositoryMock.Object);
            users = new List<User>
            {
                new User {Id = 1, Name = "aaa", Surname = "aaaa", AmountOfBooksRented = 1},
                new User {Id = 2, Name = "bbb", Surname = "bbb", AmountOfBooksRented = 4},
                new User {Id = 3, Name = "ccc", Surname = "ccc", AmountOfBooksRented = 3},
                new User {Id = 4, Name = "ddd", Surname = "ddd", AmountOfBooksRented = 1},
                new User {Id = 5, Name = "eee", Surname = "eee", AmountOfBooksRented = 4},
                new User {Id = 6, Name = "fff", Surname = "fff", AmountOfBooksRented = 6}
            };
        }

        private readonly Mock<IUserRepository> userRepositoryMock;
        private readonly UserService userService;
        private readonly List<User> users;
        private readonly User user = new User();

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(default)]
        public void ShouldGetUserById(int id)
        {
            //Arrange
            userRepositoryMock.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(user);

            //Act
            var returnedUser = userService.GetUser(id);

            //Assert
            Assert.Equal(user, returnedUser);
        }

        [Fact]
        public void ShouldAddUser()
        {
            //Arrange
            userRepositoryMock.Setup(x => x.AddUser(It.IsAny<User>()));

            //Act
            userService.AddUser(default);

            //Assert
        }

        [Fact]
        public void ShouldDeleteUser()
        {
            //Arrange
            userRepositoryMock.Setup(x => x.DeleteUser(It.IsAny<int>()));

            //Act
            userService.DeleteUser(default);

            //Assert
        }

        [Fact]
        public void ShouldEditUser()
        {
            //Arrange
            userRepositoryMock.Setup(x => x.EditUser(It.IsAny<User>()));


            //Act
            userService.EditUser(default);

            //Assert
        }

        [Fact]
        public void ShouldGetAllUsers()
        {
            //Arrange
            userRepositoryMock.Setup(x => x.GetAllUsers()).Returns(users);

            //Act
            var returnedUsers = userService.GetAllUsers();

            //Assert
            Assert.Equal(users, returnedUsers);
        }
    }
}