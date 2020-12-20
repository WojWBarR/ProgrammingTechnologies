using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class BookDictionary
    {
        public Book Book { get; set; }
        public int BooksAmount { get; set; }

        [Key] public int DictionaryId { get; set; }
    }
}