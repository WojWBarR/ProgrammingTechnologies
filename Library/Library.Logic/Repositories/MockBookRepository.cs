using Library.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Data;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class MockBookRepository : IBookRepository
    {
        private List<Book> books;

        public MockBookRepository()
        {
            books = new List<Book>
            {
                new Book {Id = 1, Title = "aaaa", BookType = BookEnum.Adventure, IsAvailable = true},
                new Book {Id = 2, Title = "bbbb", BookType = BookEnum.Roman, IsAvailable = false},
                new Book {Id = 3, Title = "cccc", BookType = BookEnum.Document, IsAvailable = false}
            };
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            return books.FirstOrDefault(i => i.Id.Equals(id));
        }

        public Book GetBookByType(BookEnum bookType)
        {
            return books.FirstOrDefault(t => t.BookType.Equals(bookType));
        }

        public void DeleteBook(int id)
        {
            Book deletedBook = books.FirstOrDefault(i => i.Id.Equals(id));

            if (deletedBook != null)
            {
                books.Remove(deletedBook);
            }
        }

        public void EditBook(Book book)
        {
            Book editedBook = books.FirstOrDefault(b => b.Id.Equals(book.Id));

            if (editedBook != null)
            {
                editedBook.Title = book.Title;
                editedBook.BookType = book.BookType;
                editedBook.IsAvailable = book.IsAvailable;
            }
        }

        public void AddBook(Book book)
        {
            Book addedBook = new Book
            {
                Id = book.Id,
                Title = book.Title,
                BookType = book.BookType,
                IsAvailable = book.IsAvailable,
            };

            books.Add(addedBook);
        }
    }
}
