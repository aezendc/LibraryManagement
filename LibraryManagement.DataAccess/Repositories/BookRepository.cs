using LibraryManagement.DataAccess.Entities;
using LibraryManagement.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManagement.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = new();
        private int _nextId = 1;

        public IEnumerable<Book> GetAll()
        {
          return _books;
        }

        public Book? GetById(int id) { 
            return _books.FirstOrDefault(b => b.Id == id);
        } 

        public Book Add(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public bool Update(Book book)
        {
            var existing = GetById(book.Id);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.ISBN = book.ISBN;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                _books.Remove(existing);
                return true;
            }
            return false;
        }
    }
}
