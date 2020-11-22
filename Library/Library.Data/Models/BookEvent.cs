using System;

namespace Library.Data
{
    public abstract class BookEvent
    {
        public User RentalUser { get; set; }
        public BookState BookInLibrary { get; set; }
        public virtual DateTime EventDate { get; set; }
    }
}