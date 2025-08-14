using LibraryApp.Models;
using LibraryApp.Services;
using Xunit;

namespace LibraryApp.Tests
{
    public class ReportServiceTests
    {
        [Fact]
        public void GenerateSummary_ShouldReturnCorrectCounts()
        {
            var bookService = new BookService();
            var memberService = new MemberService();
            var loanService = new LoanService(bookService, memberService);
            var reportService = new ReportService(bookService, memberService, loanService);

            bookService.AddBook(new Book { Id = 1, Title = "Book1", IsAvailable = true });
            memberService.AddMember(new Member { Id = 1, Name = "Member1" });
            loanService.LoanBook(1, 1);

            var summary = reportService.GenerateSummary();

            Assert.Contains("Books: 1", summary);
            Assert.Contains("Members: 1", summary);
            Assert.Contains("Loans: 1", summary);
        }
    }
}
