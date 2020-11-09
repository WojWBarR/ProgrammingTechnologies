using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IRentalRepository
    {
        List<Rental> GetAllRentals();
        Rental GetRentalById(int id);
        void DeleteRental(int id);
        void EditRental(Rental rental);
        void AddRental(Rental rental);
    }
}
