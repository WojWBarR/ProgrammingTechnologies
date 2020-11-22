using System.Collections.Generic;

namespace Library.Data
{
    public class BookState
    {
        public BookCatalog AllBooks { get; set; }
        public Dictionary<Book, int> AvailableBooksAmount { get; set; } = new Dictionary<Book, int>();
    }
}