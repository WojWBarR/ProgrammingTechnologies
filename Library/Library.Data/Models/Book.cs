using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class Book
    {
        public string Author { get; set; }
        public BookEnum BookGenre { get; set; }

        [Key] public int Id { get; set; }

        public string Name => Title + " " + Author;
        public string Title { get; set; }
    }
}