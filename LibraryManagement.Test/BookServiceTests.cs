using Xunit;
using LibraryManagement.Service.Services;
using LibraryManagement.Service.Models;
using System.Linq;

namespace LibraryManagement.Test
{
    public class BookServiceTests
    {
        [Fact]
        public void AddBook_ShouldReturnBookWithId()
        {
            var service = new BookService();
            var dto = new BookDTO { Title = "Test", Author = "Author", ISBN = "1234567890123" };
            var added = service.AddBook(dto);
            Assert.True(added.Id > 0);
            Assert.Equal("Test", added.Title);
        }

        [Fact]
        public void GetAllBooks_ShouldReturnAllAddedBooks()
        {
            var service = new BookService();
            service.AddBook(new BookDTO { Title = "A", Author = "B", ISBN = "1234567890123" });
            service.AddBook(new BookDTO { Title = "C", Author = "D", ISBN = "1234567890124" });
            var all = service.GetAllBooks().ToList();
            Assert.Equal(2, all.Count);
        }

        [Fact]
        public void GetBookById_ShouldReturnCorrectBook()
        {
            var service = new BookService();
            var added = service.AddBook(new BookDTO { Title = "Test", Author = "Author", ISBN = "1234567890123" });
            var found = service.GetBookById(added.Id);
            Assert.NotNull(found);
            Assert.Equal("Test", found!.Title);
        }

        [Fact]
        public void UpdateBook_ShouldReturnTrueIfExists()
        {
            var service = new BookService();
            var added = service.AddBook(new BookDTO { Title = "Test", Author = "Author", ISBN = "1234567890123" });
            added.Title = "Updated";
            var result = service.UpdateBook(added);
            Assert.True(result);
            Assert.Equal("Updated", service.GetBookById(added.Id)!.Title);
        }

        [Fact]
        public void UpdateBook_ShouldReturnFalseIfNotExists()
        {
            var service = new BookService();
            var result = service.UpdateBook(new BookDTO { Id = 99, Title = "X", Author = "Y", ISBN = "1234567890123" });
            Assert.False(result);
        }

        [Fact]
        public void DeleteBook_ShouldRemoveBookAndReturnTrue()
        {
            var service = new BookService();
            var added = service.AddBook(new BookDTO { Title = "Test", Author = "Author", ISBN = "1234567890123" });
            var result = service.DeleteBook(added.Id);
            Assert.True(result);
            Assert.Null(service.GetBookById(added.Id));
        }

        [Fact]
        public void DeleteBook_ShouldReturnFalseIfNotExists()
        {
            var service = new BookService();
            var result = service.DeleteBook(123);
            Assert.False(result);
        }
    }
}
