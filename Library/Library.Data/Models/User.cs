using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int AmountOfBooksRented { get; set; }
        public string FullName => Name + " " + Surname;
    }
}