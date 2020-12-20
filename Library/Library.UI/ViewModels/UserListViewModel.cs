using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Library.Data;
using Library.Logic;
using Library.UI.Commands;

namespace Library.UI.ViewModels
{
    public class UserListViewModel : BaseViewModel, IDataErrorInfo
    {
        public bool CanAdd => !(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Surname));


        public UserListViewModel()
        {
            Task.Run(() => { Users = new ObservableCollection<User>(UserService.GetAllUsers()); });
            AddCommand = new RelayCommand(Add, () => CanAdd);
            DeleteCommand = new RelayCommand(Delete, CanExecute);
            EditCommand = new RelayCommand(Edit, CanExecute);
        }

        public bool CanExecute()
        {
            return SelectedUser != null;
        }

        #region private

        private User _selectedUser;
        private UserService _userService = new UserService(new LibraryDbContext());
        private ObservableCollection<User> _users;
        private string _name;
        private string _surname;
        private int _amountOfBooksRented;

        #endregion

        #region properties

        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public Dictionary<string, string> ErrorCollection { get; } = new Dictionary<string, string>();

        #endregion

        #region errors

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                string result = null;

                switch (columnName)
                {
                    case "Name":
                        if (string.IsNullOrWhiteSpace(Name)) result = "Name cannot be empty";
                        break;
                    case "Surname":
                        if (string.IsNullOrWhiteSpace(Surname)) result = "Surname cannot be empty";
                        break;
                }

                if (ErrorCollection.ContainsKey(columnName))
                    ErrorCollection[columnName] = result;
                else if (result != null) ErrorCollection.Add(columnName, result);

                RaisePropertyChanged(nameof(ErrorCollection));
                return result;
            }
        }

        #endregion

        #region implementedProperties

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                RaisePropertyChanged(nameof(Users));
            }
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                RaisePropertyChanged(nameof(SelectedUser));
                DeleteCommand.RaiseCanExecuteChanged();
                EditCommand.RaiseCanExecuteChanged();
            }
        }

        public UserService UserService
        {
            get => _userService;
            set
            {
                _userService = value;
                Users = new ObservableCollection<User>(value.GetAllUsers());
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                RaisePropertyChanged(nameof(Surname));
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public int AmountOfBooksRented
        {
            get => _amountOfBooksRented;
            set
            {
                _amountOfBooksRented = value;
                RaisePropertyChanged(nameof(AmountOfBooksRented));
            }
        }

        #endregion

        #region commands

        public void Delete()
        {
            Task.Factory.StartNew(() => _userService.DeleteUser(SelectedUser.Id))
                .ContinueWith(t1 => UserService = _userService);

            RaisePropertyChanged(nameof(Users));
        }

        public void Add()
        {
            var user = new User
            {
                Name = Name,
                Surname = Surname,
                AmountOfBooksRented = AmountOfBooksRented
            };

            Task.Factory.StartNew(() => _userService.AddUser(user))
                .ContinueWith(t1 => UserService = _userService);

            RaisePropertyChanged(nameof(Users));
        }

        public void Edit()
        {
            var user = new User
            {
                Id = SelectedUser.Id,
                Name = Name,
                Surname = Surname,
                AmountOfBooksRented = AmountOfBooksRented
            };

            Task.Factory.StartNew(() => _userService.EditUser(user))
                .ContinueWith(t1 => UserService = _userService);

            RaisePropertyChanged(nameof(Users));
        }

        #endregion
    }
}