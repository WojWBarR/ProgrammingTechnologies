using System;
using System.Collections.Generic;
using System.Text;
using Library.UI.ViewModels;
using Xunit;

namespace Library.Tests.UnitTests.VMTests
{
    public class MainVmTests
    {
        [Fact]
        public void ShouldBeInitializedWithUserListView()
        {
            //Arrange
            var mainViewModel = new MainViewModel();

            //Act
            mainViewModel.UpdateViewCommand.Execute("Users");

            //Assert
            Assert.IsType<UserListViewModel>(mainViewModel.SelectedViewModel);
        }

        [Fact]
        public void ShouldBeInitializedWithBookListView()
        {
            //Arrange
            var mainViewModel = new MainViewModel();

            //Act
            mainViewModel.UpdateViewCommand.Execute("Books");

            //Assert
            Assert.IsType<BookListViewModel>(mainViewModel.SelectedViewModel);
        }

        [Fact]
        public void ShouldBeInitializedWithMainView()
        {
            //Arrange
            var mainViewModel = new MainViewModel();

            //Act
            mainViewModel.UpdateViewCommand.Execute("Main");

            //Assert
            Assert.IsType<MainViewModel>(mainViewModel.SelectedViewModel);
        }
    }
}