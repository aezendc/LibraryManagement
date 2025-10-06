using LibraryManagement.DataAccess.Entities;

namespace LibraryManagement.DataAccess.Repositories.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book? GetById(int id);
        Book Add(Book book);
        bool Update(Book book);
        bool Delete(int id);
    }
}
