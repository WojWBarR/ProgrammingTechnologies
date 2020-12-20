using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class BookCatalog
    {
        public ICollection<Book> Books { get; set; } = new List<Book>();

        [Key] public int CatalogId { get; set; }
    }
}