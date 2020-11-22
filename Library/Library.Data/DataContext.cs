using System.Collections.Generic;

namespace Library.Data
{
    public class DataContext
    {
        public BooksCatalog BookCatalog = new BooksCatalog();
        public List<BookEvent> BookEvents = new List<BookEvent>();
        public BookState BookState = new BookState();
        public List<User> Users = new List<User>();
    }
}