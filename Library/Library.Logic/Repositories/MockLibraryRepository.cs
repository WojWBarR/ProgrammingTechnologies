using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class MockLibraryRepository : ILibraryRepository
    {
        private List<Book> books;

        public MockLibraryRepository()
        {
            books = new List<Book>
            {
                new Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure, IsAvailable = true},
                new Book {Id = 2, Title = "bbbb", BookType = BookEnum.Roman, IsAvailable = false},
                new Book {Id = 3, Title = "cccc", BookType = BookEnum.Document, IsAvailable = false},
                new Book {Id = 4, Title = "dddd", BookType = BookEnum.Historic, IsAvailable = false},
                new Book {Id = 5, Title = "eeee", BookType = BookEnum.SciFi, IsAvailable = false},
                new Book {Id = 6, Title = "ffff", BookType = BookEnum.Document, IsAvailable = true}
            };
        }

        public List<Book> GetAllAvailableBooks()
        {
            return books.Where(x => x.IsAvailable.Equals(true)).ToList();
        }

        public List<Book> GetAllUnavailableBooks()
        {
            return books.Where(x => x.IsAvailable.Equals(false)).ToList();
        }

        public void UpdateBookState(Book book, bool isAvailable)
        {
            Book bookToUpdate = books.FirstOrDefault(i => i.Id.Equals(book.Id));

            if (bookToUpdate != null)
            {
                bookToUpdate.IsAvailable = isAvailable;
            }
        }
    }
}
