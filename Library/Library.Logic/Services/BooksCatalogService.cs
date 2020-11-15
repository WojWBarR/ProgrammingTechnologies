using System.Collections.Generic;
using Library.Data;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Services
{
    public class BooksCatalogService
    {
        private readonly IBooksCatalogRepository booksCatalogRepository;

        public BooksCatalogService(IBooksCatalogRepository booksCatalogRepository)
        {
            this.booksCatalogRepository = booksCatalogRepository;
        }

        public void AddBook(BooksCatalog.Book book)
        {
            booksCatalogRepository.AddBook(book);
        }

        public void DeleteBook(int id)
        {
            booksCatalogRepository.DeleteBook(id);
        }

        public void EditBook(BooksCatalog.Book book)
        {
            booksCatalogRepository.EditBook(book);
        }

        public List<BooksCatalog.Book> GetAllBooks()
        {
            var books = booksCatalogRepository.GetAllBooks();

            return books.Count == 0 ? null : books;
        }

        public BooksCatalog.Book GetBook(int id)
        {
            var bookById = booksCatalogRepository.GetBookById(id);

            if (bookById.Equals(null)) return null;

            return bookById;
        }

        public BooksCatalog.Book GetBook(BookEnum bookType)
        {
            var bookByType = booksCatalogRepository.GetBookByType(bookType);

            if (bookByType.Equals(null)) return null;

            return bookByType;
        }
    }
}