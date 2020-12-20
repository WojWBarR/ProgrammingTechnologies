using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class User
    {
        public int AmountOfBooksRented { get; set; }
        public string FullName => Name + " " + Surname;

        [Key] public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}