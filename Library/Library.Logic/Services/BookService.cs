using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Logic.Services
{
    public class BookService
    {
        private readonly IBooksStateRepository bookRepository;

        public BookService(IBooksStateRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = bookRepository.GetAllBooks();

            return books.Count == 0 ? null : books;
        }

        public Book GetBook(int id)
        {
            Book book = bookRepository.GetBookById(id);

            if (book.Equals(null))
            {
                return null;
            }

            return book;
        }

        public Book GetBook(BookEnum bookType)
        {
            Book book = bookRepository.GetBookByType(bookType);

            if (book.Equals(null))
            {
                return null;
            }

            return book;
        }

        public void DeleteBook(int id)
        {
            bookRepository.DeleteBook(id);
        }

        public void EditBook(Book book)
        {
            bookRepository.EditBook(book);
        }

        public void AddBook(Book book)
        {
            bookRepository.AddBook(book);
        }
    }
}
