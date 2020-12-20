using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Data;
using Library.Logic;
using Library.UI.Commands;

namespace Library.UI.ViewModels
{
    public class BookListViewModel : BaseViewModel, IDataErrorInfo
    {
        #region private
        private Book _selectedBook;
        private BooksCatalogService _bookService = new BooksCatalogService(new LibraryDbContext());
        private ObservableCollection<Book> _books;
        private string _title;
        private string _author;
        private BookEnum _bookGenre;
        #endregion

        #region properties
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        #endregion

        public BookListViewModel()
        {
            Task.Run(() =>
            {
                Books = new ObservableCollection<Book>(BookService.GetAllBooks());
            });
            AddCommand = new RelayCommand(Add, () => CanAdd);
            DeleteCommand = new RelayCommand(Delete, CanExecute);
            EditCommand = new RelayCommand(Edit, CanExecute);
        }

        #region errors
        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;

                switch (columnName)
                {
                    case "Title":
                        if (string.IsNullOrWhiteSpace(Title))
                        {
                            result = "Title cannot be empty";

                        }
                        break;
                    case "Author":
                        if (string.IsNullOrWhiteSpace(Author))
                        {
                            result = "Author cannot be empty";
                        }
                        break;
                }

                if (ErrorCollection.ContainsKey(columnName))
                {
                    ErrorCollection[columnName] = result;
                }
                else if (result != null)
                {
                    ErrorCollection.Add(columnName, result);
                }

                RaisePropertyChanged(nameof(ErrorCollection));
                return result;
            }
        }
        #endregion

        #region implementedProperties
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                RaisePropertyChanged(nameof(Books));
            }
        }

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                RaisePropertyChanged(nameof(SelectedBook));
                DeleteCommand.RaiseCanExecuteChanged();
                EditCommand.RaiseCanExecuteChanged();
            }
        }

        public BooksCatalogService BookService
        {
            get { return _bookService; }
            set
            {
                _bookService = value;
                Books = new ObservableCollection<Book>(value.GetAllBooks());
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(nameof(Title));
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                RaisePropertyChanged(nameof(Author));
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public BookEnum BookGenre
        {
            get { return _bookGenre; }
            set
            {
                _bookGenre = value;
                RaisePropertyChanged(nameof(BookGenre));
            }
        }
        #endregion

        #region commands
        public void Delete()
        {
            Task.Factory.StartNew(() => _bookService.DeleteBook(SelectedBook.Id))
                .ContinueWith((t1) => BookService = _bookService);

            RaisePropertyChanged(nameof(Books));
        }

        public void Add()
        {
            Book book = new Book
            {
                Title = Title,
                Author = Author,
                BookGenre = BookGenre
            };

            Task.Factory.StartNew(() => _bookService.AddBook(book))
                .ContinueWith((t1) => BookService = _bookService);

            RaisePropertyChanged(nameof(Books));
        }

        public void Edit()
        {
            Book book = new Book
            {
                Id = SelectedBook.Id,
                Title = Title,
                Author = Author,
                BookGenre = BookGenre
            };

            Task.Factory.StartNew(() => _bookService.EditBook(book))
                .ContinueWith((t1) => BookService = _bookService);

            RaisePropertyChanged(nameof(Books));
        }
        #endregion

        private bool CanExecute()
        {
            return SelectedBook != null;
        }

        private bool CanAdd
        {
            get { return !(((string.IsNullOrEmpty(this.Title)) || (string.IsNullOrEmpty(this.Author)))); }
        }
    }
}
