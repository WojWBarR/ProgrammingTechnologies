using System.Collections.Generic;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class MockBookEventRepository : IBookEventRepository
    {
        private readonly MockDbContext dbContext;

        public MockBookEventRepository(MockDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<BookEvent> GetAllBookEvents()
        {
            return dbContext.BookEvents();
        }

        public void AddRentalEvent(RentalEvent rentalEvent)
        {
            var addedRentalEvent = new RentalEvent
            {
                BooksInLibrary = rentalEvent.BooksInLibrary,
                RentalDate = rentalEvent.RentalDate,
                RentalUser = rentalEvent.RentalUser
            };

            dbContext.BookEvents().Add(addedRentalEvent);
        }

        public void AddReturnEvent(ReturnEvent returnEvent)
        {
            var addedReturnEvent = new ReturnEvent
            {
                ReturnDate = returnEvent.ReturnDate,
                RentalUser = returnEvent.RentalUser
            };

            dbContext.BookEvents().Add(addedReturnEvent);
        }
    }
}