using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Data.Models
{
    public class BookDictionary
    {
        [Key]
        public int DictionaryId { get; set; }
        public Book Book { get; set; }
        public int BooksAmount { get; set; }
    }
}
