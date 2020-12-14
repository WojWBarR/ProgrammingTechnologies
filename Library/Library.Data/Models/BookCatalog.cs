using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class BookCatalog
    {
        [Key]
        public int CatalogId { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}