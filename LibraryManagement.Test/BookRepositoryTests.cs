using Xunit;
using LibraryManagement.DataAccess.Repositories;
using LibraryManagement.DataAccess.Entities;
using System.Linq;

namespace LibraryManagement.Test
{
    public class BookRepositoryTests
    {
        [Fact]
        public void AddBook_ShouldAssignIdAndAddToList()
        {
            var repo = new BookRepository();
            var book = new Book { Title = "Test", Author = "Author", ISBN = "1234567890123" };
            var added = repo.Add(book);
            Assert.Equal(1, added.Id);
            Assert.Single(repo.GetAll());
        }

        [Fact]
        public void GetById_ShouldReturnCorrectBook()
        {
            var repo = new BookRepository();
            var added = repo.Add(new Book { Title = "Test", Author = "Author", ISBN = "1234567890123" });
            var found = repo.GetById(added.Id);
            Assert.NotNull(found);
            Assert.Equal("Test", found!.Title);
        }

        [Fact]
        public void Update_ShouldReturnTrueIfExists()
        {
            var repo = new BookRepository();
            var added = repo.Add(new Book { Title = "Test", Author = "Author", ISBN = "1234567890123" });
            added.Title = "Updated";
            var result = repo.Update(added);
            Assert.True(result);
            Assert.Equal("Updated", repo.GetById(added.Id)!.Title);
        }

        [Fact]
        public void Update_ShouldReturnFalseIfNotExists()
        {
            var repo = new BookRepository();
            var result = repo.Update(new Book { Id = 99, Title = "X", Author = "Y", ISBN = "1234567890123" });
            Assert.False(result);
        }

        [Fact]
        public void Delete_ShouldRemoveBookAndReturnTrue()
        {
            var repo = new BookRepository();
            var added = repo.Add(new Book { Title = "Test", Author = "Author", ISBN = "1234567890123" });
            var result = repo.Delete(added.Id);
            Assert.True(result);
            Assert.Empty(repo.GetAll());
        }

        [Fact]
        public void Delete_ShouldReturnFalseIfNotExists()
        {
            var repo = new BookRepository();
            var result = repo.Delete(123);
            Assert.False(result);
        }
    }
}