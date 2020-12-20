using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Logic;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Library.LogicTests
{
    public class UserServiceTests
    {
        private IQueryable<User> _users;
        private readonly Mock<LibraryDbContext> _libraryDbContextMock;
        private readonly Mock<DbSet<User>> _mockSet;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _users = new List<User>
            {
                new User{ Id = 0, Name = "aaa"},
                new User{ Id = 1 ,Name = "bbb"},
                new User{ Id = 2 ,Name = "ccc"},
            }.AsQueryable();

            _mockSet = new Mock<DbSet<User>>();
            _mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(_users.Provider);
            _mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(_users.Expression);
            _mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(_users.ElementType);
            _mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(_users.GetEnumerator());

            _libraryDbContextMock = new Mock<LibraryDbContext>();
            _libraryDbContextMock.Setup(x => x.Users).Returns(_mockSet.Object);

            _userService = new UserService(_libraryDbContextMock.Object);
        }

        [Fact]
        public void ShouldReturnAllUsers()
        {
            //Arrange

            //Act
            var resultedUsers = _userService.GetAllUsers();

            //Assert
            Assert.Equal(3, resultedUsers.Count());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void ShouldReturnUserById(int id)
        {
            //Arrange

            //Act
            var resultedUser = _userService.GetUserById(id);

            //Assert
            switch (id)
            {
                case 0:
                    Assert.Equal("aaa", resultedUser.Name);
                    break;
                case 1:
                    Assert.Equal("bbb", resultedUser.Name);
                    break;
                case 2:
                    Assert.Equal("ccc", resultedUser.Name);
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
            _userService.AddUser(newUser);

            //Assert
            _libraryDbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ShouldDeleteUser()
        {
            //Arrange

            //Act
            _userService.DeleteUser(1);

            //Assert
            _libraryDbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ShouldEditUser()
        {
            //Arrange
            var editedUser = new User
            {
                Id = 1,
                Name = "fff",
                Surname = "fff",
                AmountOfBooksRented = 30
            };

            //Act
            _userService.EditUser(editedUser);

            //Assert
            _libraryDbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}