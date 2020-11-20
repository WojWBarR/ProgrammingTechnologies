using System.Collections.Generic;

namespace Library.Data
{
    public class BookEventRepository : IBookEventRepository
    {
        private readonly DataContext _dataContext;

        public BookEventRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<BookEvent> GetAllBookEvents()
        {
            return _dataContext.BookEvents;
        }

        public void AddRentalEvent(RentalEvent rentalEvent)
        {
            var addedRentalEvent = new RentalEvent
            {
                BookInLibrary = rentalEvent.BookInLibrary,
                EventDate = rentalEvent.EventDate,
                RentalUser = rentalEvent.RentalUser
            };

            _dataContext.BookEvents.Add(addedRentalEvent);
        }

        public void AddReturnEvent(ReturnEvent returnEvent)
        {
            var addedReturnEvent = new ReturnEvent
            {
                EventDate = returnEvent.EventDate,
                RentalUser = returnEvent.RentalUser
            };

            _dataContext.BookEvents.Add(addedReturnEvent);
        }
    }
}