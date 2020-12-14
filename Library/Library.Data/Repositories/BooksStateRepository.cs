﻿using System.Collections.Generic;
using System.Linq;
using Library.Data.Models;

namespace Library.Data
{
    public class BooksStateRepository : IBooksStateRepository
    {
        private readonly DataContext _dataContext;
        private readonly LibraryDbContext _dbContext;

        public BooksStateRepository(DataContext dataContext, LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> GetAllAvailableBooks()
        {
            return _dbContext.Set<Book>();
        }

        public int GetAmountOfAvailableBooksById(int dictionaryId)
        {
            var bookDictionary = _dbContext.Set<BookDictionary>().FirstOrDefault(i => i.DictionaryId.Equals(dictionaryId));

            if (bookDictionary?.Book != null)
            {
                var amount = bookDictionary.BooksAmount;

                return amount > 0 ? amount : default;
            }

            return default;
        }

        public int UpdateBooksAmount(int dictionaryId, int actualBooksAmount)
        {
            var bookDictionary = _dbContext.Set<BookDictionary>().FirstOrDefault(i => i.DictionaryId.Equals(dictionaryId));

            if (bookDictionary?.Book != null)
            {
                bookDictionary.BooksAmount = actualBooksAmount;

                _dbContext.SaveChanges();

                return bookDictionary.BooksAmount;
            }

            return default;
        }
    }
}