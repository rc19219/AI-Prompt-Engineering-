using LibraryApp.Models;

namespace LibraryApp.Services
{
    public class LoanService
    {
        private readonly List<Loan> loans = new();
        private readonly BookService bookService;
        private readonly MemberService memberService;

        public LoanService(BookService bookService, MemberService memberService)
        {
            this.bookService = bookService;
            this.memberService = memberService;
        }

        public bool LoanBook(int bookId, int memberId)
        {
            var book = bookService.GetBook(bookId);
            var member = memberService.GetMember(memberId);

            if (book == null || member == null || !book.IsAvailable)
                return false;

            book.IsAvailable = false;
            loans.Add(new Loan
            {
                BookId = bookId,
                MemberId = memberId,
                LoanDate = DateTime.Now
            });

            return true;
        }

        public bool ReturnBook(int bookId)
        {
            var loan = loans.FirstOrDefault(l => l.BookId == bookId && l.ReturnDate == null);
            if (loan == null) return false;

            loan.ReturnDate = DateTime.Now;
            var book = bookService.GetBook(bookId);
            if (book != null) book.IsAvailable = true;

            return true;
        }

        public IEnumerable<Loan> GetAllLoans() => loans;
    }
}
