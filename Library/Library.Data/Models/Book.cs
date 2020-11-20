namespace Library.Data
{
    public class Book
    {
        public string Author { get; set; }
        public BookEnum BookGenre { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
    }
}