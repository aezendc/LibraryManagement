using LibraryManagement.Service.Models;
using LibraryManagement.Service.Services.Interfaces;
using LibraryManagement.DataAccess.Repositories;
using LibraryManagement.DataAccess.Repositories.Interfaces;
using LibraryManagement.DataAccess.Entities;

namespace LibraryManagement.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        // BookService controls its dependency on DataAccess (App never knows)
        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            return _bookRepository.GetAll().Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN
            });
        }

        public BookDTO? GetBookById(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null) return null;

            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN
            };
        }

        public BookDTO AddBook(BookDTO book)
        {
            var added = _bookRepository.Add(new Book
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN
            });
            return new BookDTO
            {
                Id = added.Id,
                Title = added.Title,
                Author = added.Author,
                ISBN = added.ISBN
            };
        }

        public bool UpdateBook(BookDTO book)
        {
            return _bookRepository.Update(new Book
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN
            });
        }

        public bool DeleteBook(int id)
        { 
            return _bookRepository.Delete(id);
        } 
    }
}
