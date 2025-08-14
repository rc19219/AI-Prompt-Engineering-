using LibraryApp.Models;

namespace LibraryApp.Services
{
    public class BookService
    {
        private readonly List<Book> books = new();

        public void AddBook(Book book) => books.Add(book);
        public Book GetBook(int id) => books.FirstOrDefault(b => b.Id == id);
        public IEnumerable<Book> GetAllBooks() => books;
    }
}
