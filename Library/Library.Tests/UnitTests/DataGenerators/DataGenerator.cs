using System.Collections.Generic;
using Library.Data;

namespace Library.DataTests
{
    public class DataGenerator : IDataGenerator
    {
        public DataContext GenerateData()
        {
            var dataContext = new DataContext();

            var user1 = new User { Id = 1, Name = "aaa", Surname = "aaa", AmountOfBooksRented = 1 };
            var user2 = new User { Id = 2, Name = "bbb", Surname = "bbb", AmountOfBooksRented = 4 };
            var user3 = new User { Id = 3, Name = "ccc", Surname = "ccc", AmountOfBooksRented = 3 };
            var user4 = new User { Id = 4, Name = "ddd", Surname = "ddd", AmountOfBooksRented = 1 };
            var user5 = new User { Id = 5, Name = "eee", Surname = "eee", AmountOfBooksRented = 4 };
            var user6 = new User { Id = 6, Name = "fff", Surname = "fff", AmountOfBooksRented = 6 };

            dataContext.Users.Add(user1);
            dataContext.Users.Add(user2);
            dataContext.Users.Add(user3);
            dataContext.Users.Add(user4);
            dataContext.Users.Add(user5);
            dataContext.Users.Add(user6);

            var book1 = new Book { Id = 1, Title = "aaaa", BookGenre = BookEnum.Adventure, Author = "Aaaa" };
            var book2 = new Book { Id = 2, Title = "bbbb", BookGenre = BookEnum.Roman, Author = "Bbbb" };
            var book3 = new Book { Id = 3, Title = "cccc", BookGenre = BookEnum.Document, Author = "Cccc" };
            var book4 = new Book { Id = 4, Title = "dddd", BookGenre = BookEnum.Historic, Author = "Aaaa" };
            var book5 = new Book { Id = 5, Title = "eeee", BookGenre = BookEnum.SciFi, Author = "Bbbb" };
            var book6 = new Book { Id = 6, Title = "ffff", BookGenre = BookEnum.Document, Author = "Cccc" };

            dataContext.BookCatalog.Books.Add(book1);
            dataContext.BookCatalog.Books.Add(book2);
            dataContext.BookCatalog.Books.Add(book3);
            dataContext.BookCatalog.Books.Add(book4);
            dataContext.BookCatalog.Books.Add(book5);
            dataContext.BookCatalog.Books.Add(book6);


            var bookState = new BookState
            {
                AllBooks = dataContext.BookCatalog,
                /*AvailableBooksAmount = new Dictionary<Book, int>
                {
                    {book1, 32},
                    {book2, 2},
                    {book3, 18},
                    {book4, 6},
                    {book5, 2},
                    {book6, 40}
                }*/
            };

            dataContext.BookState = bookState;

            var rentalEvent1 = new RentalEvent { EventDate = default, RentalUser = user1, BookInLibrary = bookState };
            var rentalEvent2 = new RentalEvent { EventDate = default, RentalUser = user2, BookInLibrary = bookState };
            var rentalEvent3 = new RentalEvent { EventDate = default, RentalUser = user3, BookInLibrary = bookState };
            var returnEvent1 = new ReturnEvent { EventDate = default, RentalUser = user2 };
            var returnEvent2 = new ReturnEvent { EventDate = default, RentalUser = user3 };

            dataContext.BookEvents.Add(rentalEvent1);
            dataContext.BookEvents.Add(rentalEvent2);
            dataContext.BookEvents.Add(rentalEvent3);
            dataContext.BookEvents.Add(returnEvent1);
            dataContext.BookEvents.Add(returnEvent2);

            return dataContext;
        }
    }
}
