using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data
{
    public abstract class BookEvent
    {
        [Key]
        public int EventId { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User RentalUser { get; set; }

        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public BookState BookInLibrary { get; set; }
        public virtual DateTime EventDate { get; set; }
    }
}