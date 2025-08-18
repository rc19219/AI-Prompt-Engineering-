using LibraryApp.Models;
using LibraryApp.Services;
using Xunit;

namespace LibraryApp.Tests
{
    public class LoanServiceTests
    {
        [Fact]
        public void LoanBook_ShouldMarkBookUnavailable()
        {
            var bookService = new BookService();
            var memberService = new MemberService();
            var loanService = new LoanService(bookService, memberService);

            var book = new Book { Id = 1, Title = "Book1", IsAvailable = true };
            var member = new Member { Id = 1, Name = "Alice" };
            bookService.AddBook(book);
            memberService.AddMember(member);

            var result = loanService.LoanBook(1, 1);

            Assert.True(result);
            Assert.False(bookService.GetBook(1).IsAvailable);
        }

        [Fact]
        public void ReturnBook_ShouldMarkBookAvailable()
        {
            var bookService = new BookService();
            var memberService = new MemberService();
            var loanService = new LoanService(bookService, memberService);

            var book = new Book { Id = 1, Title = "Book1", IsAvailable = true };
            var member = new Member { Id = 1, Name = "Alice" };
            bookService.AddBook(book);
            memberService.AddMember(member);
            loanService.LoanBook(1, 1);

            var result = loanService.ReturnBook(1);

            Assert.True(result);
            Assert.True(bookService.GetBook(1).IsAvailable);
        }

        [Fact]
public void ReturnBook_BookWasNotBorrowed_ShouldThrowException()
{
    // Arrange
    var bookService = new BookService();
    var memberService = new MemberService();
    var loanService = new LoanService(bookService, memberService);

    var book = new Book { Id = 1, Title = "1984", Author = new Author { Name = "George Orwell" } };
    var member = new Member { Id = 1, Name = "John Doe" };

    bookService.AddBook(book);
    memberService.AddMember(member);

    Act & Assert
    Assert.Throws<InvalidOperationException>(() =>
        loanService.ReturnBook(book.Id)
    );
}

    }
}
