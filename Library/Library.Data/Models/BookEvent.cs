using System;

namespace Library.Data
{
    public abstract class BookEvent
    {
        public User RentalUser { get; set; }
        public BooksState BookInLibrary { get; set; }
        public virtual DateTime EventDate { get; set; }
    }
}