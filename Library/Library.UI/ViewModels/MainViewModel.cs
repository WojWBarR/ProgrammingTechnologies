using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Library.Logic;
using Library.UI.Commands;

namespace Library.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                RaisePropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateMainViewCommand(this);
        }
    }
}