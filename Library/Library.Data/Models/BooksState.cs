using System.Collections.Generic;

namespace Library.Data.Models
{
    public class BooksState
    {
        public Dictionary<int, int> AvailableBooksAmount { get; set; } = new Dictionary<int, int>();
        public BooksCatalog AvailableBooks { get; set; }
    }
}