using LibraryApp.Models;
using LibraryApp.Services;
using Xunit;

namespace LibraryApp.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void AddBook_ShouldAddBookSuccessfully()
        {
            var service = new BookService();
            var book = new Book { Id = 1, Title = "Test Book", IsAvailable = true };
            
            service.AddBook(book);
            var retrieved = service.GetBook(1);

            Assert.NotNull(retrieved);
            Assert.Equal("Test Book", retrieved.Title);
        }
    }
}
