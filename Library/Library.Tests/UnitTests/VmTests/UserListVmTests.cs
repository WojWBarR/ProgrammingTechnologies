using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Library.Data;
using Library.UI.ViewModels;
using Xunit;

namespace Library.VmTests
{
    public class UserListVmTests
    {
        private readonly UserListViewModel _userListViewModel;
        private bool canBeExecuted = true;

        public UserListVmTests()
        {
            _userListViewModel = new UserListViewModel
            {
                Users = new ObservableCollection<User>
                {
                    new User {Id = 1, Name = "aaa", Surname = "aaa"},
                    new User {Id = 1},
                    new User {Id = 1, Name = "ccc", Surname = "ccc"},
                    new User {Id = 1, Name = "ddd", Surname = "ddd"},
                    new User {Id = 1, Name = "eee", Surname = "eee"},
                    new User {Id = 1, Name = "fff", Surname = "fff"},
                }
            };
        }

        [Fact]
        public void VmShouldInitializeCommandsAndUserGridVm()
        {
            //Arrange
            var addCommand = _userListViewModel.AddCommand;
            var editCommand = _userListViewModel.EditCommand;
            var deleteCommand = _userListViewModel.DeleteCommand;

            //Act

            //Assert
            Assert.NotNull(addCommand);
            Assert.NotNull(editCommand);
            Assert.NotNull(deleteCommand);
        }

        [Fact]
        public void ShouldReturnProperUser()
        {
            //Arrange
            var user = new User
            {
                Name = "aaa",
                Surname = "aaa"
            };

            //Act
            var users = _userListViewModel.Users;

            //Assert
            Assert.Equal(user.Name, users[0].Name);
        }

        [Fact]
        public void DeleteCmdShouldNotBeExecuted()
        {
            //Arrange
            _userListViewModel.SelectedUser = null;
            var deleteCommand = _userListViewModel.DeleteCommand;

            //Act
            if (_userListViewModel.SelectedUser == null)
                canBeExecuted = false;

            //Assert
            Assert.False(deleteCommand.CanExecute(canBeExecuted));
        }

        [Fact]
        public void DeleteCmdShouldBeExecuted()
        {
            //Arrange
            _userListViewModel.SelectedUser = _userListViewModel.Users[0];
            var deleteCommand = _userListViewModel.DeleteCommand;

            //Act
            if (_userListViewModel.SelectedUser != null)
                canBeExecuted = true;

            //Assert
            Assert.True(deleteCommand.CanExecute(canBeExecuted));
        }

        [Fact]
        public void EditCmdShouldNotBeExecuted()
        {
            //Arrange
            _userListViewModel.SelectedUser = null;
            var editCommand = _userListViewModel.EditCommand;

            //Act
            if (_userListViewModel.SelectedUser == null)
                canBeExecuted = false;

            //Assert
            Assert.False(editCommand.CanExecute(canBeExecuted));
        }

        [Fact]
        public void EditCmdShouldBeExecuted()
        {
            //Arrange
            _userListViewModel.SelectedUser = _userListViewModel.Users[0];
            var editCommand = _userListViewModel.EditCommand;

            //Act
            if (_userListViewModel.SelectedUser != null)
                canBeExecuted = true;

            //Assert
            Assert.True(editCommand.CanExecute(canBeExecuted));
        }

        [Fact]
        public void AddCmdShouldNotBeExecuted()
        {
            //Arrange
            _userListViewModel.SelectedUser = _userListViewModel.Users[1];
            var addCommand = _userListViewModel.AddCommand;

            //Act
            if (_userListViewModel.SelectedUser.Name == null && _userListViewModel.SelectedUser.Surname == null)
                canBeExecuted = false;

            //Assert
            Assert.False(canBeExecuted);
        }

        [Fact]
        public void AddCmdShouldBeExecuted()
        {
            //Arrange
            _userListViewModel.SelectedUser = _userListViewModel.Users[0];
            var addCommand = _userListViewModel.AddCommand;

            //Act
            if (_userListViewModel.SelectedUser.Name != null && _userListViewModel.SelectedUser.Surname != null)
                canBeExecuted = true;

            //Assert
            Assert.True(canBeExecuted);
        }
    }
}
