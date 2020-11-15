using System.Collections.Generic;

namespace Library.Data.Models
{
    public class BooksCatalog
    {
        public List<Book> Books { get; set; } = new List<Book>();

        public class Book
        {
            public BookEnum BookType { get; set; }
            public int Id { get; set; }
            public string Title { get; set; }
        }
    }
}
