using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Library.Logic.ViewModels;

namespace Library.Logic.Commands
{
    class UpdateMainViewCommand : ICommand
    {
        private readonly MainViewModel _viewModel;

        public UpdateMainViewCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Users")
            {
                _viewModel.SelectedViewModel = new UserListViewModel();
            }
            else if (parameter.ToString() == "Books")
            {
                _viewModel.SelectedViewModel = new BookCatalogViewModel();
            }
            else if (parameter.ToString() == "Events")
            {
                _viewModel.SelectedViewModel = new EventListViewModel();
            }
        }
    }

}