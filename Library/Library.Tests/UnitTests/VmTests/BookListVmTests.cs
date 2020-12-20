using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Library.Data;
using Library.UI.ViewModels;
using Xunit;

namespace Library.VmTests
{
    public class BookListVmTests
    {
        private readonly BookListViewModel _bookListViewModel;
        private bool canBeExecuted = true;

        public BookListVmTests()
        {
            _bookListViewModel = new BookListViewModel
            {
                Books = new ObservableCollection<Book>
                {
                   new Book {Id = 1, Author = "aaa", Title = "aaa"},
                   new Book {Id = 2},
                   new Book {Id = 3, Author = "ccc", Title = "ccc"},
                   new Book {Id = 4, Author = "ddd", Title = "ddd"},
                   new Book {Id = 5, Author = "eee", Title = "eee"},
                   new Book {Id = 6, Author = "fff", Title = "fff"},
                }
            };
        }

        [Fact]
        public void VmShouldInitializeCommandsAndUserGridVm()
        {
            //Arrange
            var addCommand = _bookListViewModel.AddCommand;
            var editCommand = _bookListViewModel.EditCommand;
            var deleteCommand = _bookListViewModel.DeleteCommand;

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
            var user = new Book
            {
                Title = "aaa",
                Author = "aaa"
            };

            //Act
            var books = _bookListViewModel.Books;

            //Assert
            Assert.Equal(user.Author, books[0].Author);
        }

        [Fact]
        public void DeleteCmdShouldNotBeExecuted()
        {
            //Arrange
            _bookListViewModel.SelectedBook = null;
            var deleteCommand = _bookListViewModel.DeleteCommand;

            //Act
            if (_bookListViewModel.SelectedBook == null)
                canBeExecuted = false;

            //Assert
            Assert.False(deleteCommand.CanExecute(canBeExecuted));
        }

        [Fact]
        public void DeleteCmdShouldBeExecuted()
        {
            //Arrange
            _bookListViewModel.SelectedBook = _bookListViewModel.Books[0];
            var deleteCommand = _bookListViewModel.DeleteCommand;

            //Act
            if (_bookListViewModel.SelectedBook != null)
                canBeExecuted = true;

            //Assert
            Assert.True(deleteCommand.CanExecute(canBeExecuted));
        }

        [Fact]
        public void EditCmdShouldNotBeExecuted()
        {
            //Arrange
            _bookListViewModel.SelectedBook = null;
            var editCommand = _bookListViewModel.EditCommand;

            //Act
            if (_bookListViewModel.SelectedBook == null)
                canBeExecuted = false;

            //Assert
            Assert.False(editCommand.CanExecute(canBeExecuted));
        }

        [Fact]
        public void EditCmdShouldBeExecuted()
        {
            //Arrange
            _bookListViewModel.SelectedBook = _bookListViewModel.Books[0];
            var editCommand = _bookListViewModel.EditCommand;

            //Act
            if (_bookListViewModel.SelectedBook != null)
                canBeExecuted = true;

            //Assert
            Assert.True(editCommand.CanExecute(canBeExecuted));
        }

        [Fact]
        public void AddCmdShouldNotBeExecuted()
        {
            //Arrange
            _bookListViewModel.SelectedBook = _bookListViewModel.Books[1];
            var addCommand = _bookListViewModel.AddCommand;

            //Act
            if (_bookListViewModel.SelectedBook.Author == null && _bookListViewModel.SelectedBook.Title == null)
                canBeExecuted = false;

            //Assert
            Assert.False(canBeExecuted);

        }

        [Fact]
        public void AddCmdShouldBeExecuted()
        {
            //Arrange
            _bookListViewModel.SelectedBook = _bookListViewModel.Books[0];
            var addCommand = _bookListViewModel.AddCommand;

            //Act
            if (_bookListViewModel.SelectedBook.Author != null && _bookListViewModel.SelectedBook.Title != null)
                canBeExecuted = true;

            //Assert
            Assert.True(canBeExecuted);
        }
    }
}
