using System.Collections.Generic;

namespace Library.Data
{
    public interface IBookEventRepository
    {
        void AddRentalEvent(RentalEvent rentalEvent);
        void AddReturnEvent(ReturnEvent returnEvent);
        List<BookEvent> GetAllBookEvents();
    }
}