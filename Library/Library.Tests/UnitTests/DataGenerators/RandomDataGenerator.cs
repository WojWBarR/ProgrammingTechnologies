using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;

namespace Library.DataTests
{
    public class RandomDataGenerator : IDataGenerator
    {
        private readonly DataContext dataContext = new DataContext();
        private readonly Random random = new Random();

        public DataContext GenerateData()
        {
            var randomUser = CreateRandomUser();
            dataContext.Users.Add(randomUser);

            var randomBook = CreateRandomBook();
            dataContext.BookCatalog.Books.Add(randomBook);

            var randomBookState = CreateRandomBookState();
            dataContext.BookState = randomBookState;

            var randomRentalEvent = CreateRandomRentalEvent();
            var randomReturnEvent = CreateRandomReturnEvent();
            dataContext.BookEvents.Add(randomRentalEvent);
            dataContext.BookEvents.Add(randomReturnEvent);

            return dataContext;
        }

        public Book CreateRandomBook()
        {
            var book = new Book
            {
                Id = RandomNumber(1, 100),
                Author = RandomString(20),
                BookGenre = RandomGenre(),
                Title = RandomString(10)
            };

            return book;
        }

        public BookState CreateRandomBookState()
        {
            var bookState = new BookState
            {
                AllBooks = dataContext.BookCatalog,
                /*AvailableBooksAmount = new Dictionary<Book, int>
                {
                    {CreateRandomBook(), RandomNumber(1, 10)},
                    {CreateRandomBook(), RandomNumber(1, 10)},
                    {CreateRandomBook(), RandomNumber(1, 10)},
                    {CreateRandomBook(), RandomNumber(1, 10)},
                    {CreateRandomBook(), RandomNumber(1, 10)},
                    {CreateRandomBook(), RandomNumber(1, 10)}
                }*/
            };

            return bookState;
        }

        public RentalEvent CreateRandomRentalEvent()
        {
            var rentalEvent = new RentalEvent
            {
                BookInLibrary = CreateRandomBookState(),
                EventDate = default,
                RentalUser = CreateRandomUser()
            };

            return rentalEvent;
        }

        public ReturnEvent CreateRandomReturnEvent()
        {
            var returnEvent = new ReturnEvent
            {
                RentalUser = CreateRandomUser(),
                EventDate = default
            };

            return returnEvent;
        }

        public User CreateRandomUser()
        {
            var user = new User
            {
                Id = RandomNumber(1, 20),
                Name = RandomString(6),
                Surname = RandomString(10),
                AmountOfBooksRented = RandomNumber(0, 15)
            };

            return user;
        }

        private BookEnum RandomGenre()
        {
            var values = Enum.GetValues(typeof(BookEnum));
            var randomGenre = (BookEnum)values.GetValue(random.Next(values.Length));
            return randomGenre;
        }

        private int RandomNumber(int bottomBorder, int upperBorder)
        {
            return random.Next(bottomBorder, upperBorder);
        }

        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}