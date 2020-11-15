using System.Collections.Generic;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IBookEventRepository
    {
        void AddRentalEvent(RentalEvent rentalEvent);
        void AddReturnEvent(ReturnEvent returnEvent);
        List<BookEvent> GetAllBookEvents();
    }
}