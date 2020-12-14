using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Library.Data.Models;

namespace Library.Data
{
    public class BookState
    {
        [Key]
        public int StateId { get; set; }
        public BookCatalog AllBooks { get; set; }
        public BookDictionary AvailableBooks { get; set; }
    }
}