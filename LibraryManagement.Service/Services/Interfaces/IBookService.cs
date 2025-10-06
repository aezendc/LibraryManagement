using LibraryManagement.Service.Models;

namespace LibraryManagement.Service.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAllBooks();
        BookDTO? GetBookById(int id);
        BookDTO AddBook(BookDTO book);
        bool UpdateBook(BookDTO book);
        bool DeleteBook(int id);
    }
}
