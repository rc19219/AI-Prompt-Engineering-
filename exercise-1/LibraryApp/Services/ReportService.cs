using LibraryApp.Models;

namespace LibraryApp.Services
{
    public class ReportService
    {
        private readonly BookService bookService;
        private readonly MemberService memberService;
        private readonly LoanService loanService;

        public ReportService(BookService bService, MemberService mService, LoanService lService)
        {
            bookService = bService;
            memberService = mService;
            loanService = lService;
        }

        public string GenerateSummary()
        {
            return $"Books: {bookService.GetAllBooks().Count()}, " +
                   $"Members: {memberService.GetAllMembers().Count()}, " +
                   $"Loans: {loanService.GetAllLoans().Count()}";
        }
    }
}
