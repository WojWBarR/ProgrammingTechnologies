using System.ComponentModel.DataAnnotations;
using Library.Data.Models;

namespace Library.Data
{
    public class BookState
    {
        public BookCatalog AllBooks { get; set; }
        public BookDictionary AvailableBooks { get; set; }

        [Key] public int StateId { get; set; }
    }
}