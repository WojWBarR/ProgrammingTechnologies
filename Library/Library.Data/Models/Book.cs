using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        public BookEnum BookGenre { get; set; }
        public string Title { get; set; }
        public string Name => Title + " " + Author;
    }
}