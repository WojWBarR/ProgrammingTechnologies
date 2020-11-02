using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime GiveBackDate { get; set; }
        public User RentalUser { get; set; }
        public OurLibrary LibraryBooks { get; set; }
    }
}
