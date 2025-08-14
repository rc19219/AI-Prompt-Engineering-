#pragma warning disable CS8618, CS8603

using LibraryApp.Models;
using LibraryApp.Services;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=================================");
            Console.WriteLine("  📚  LIBRARY MANAGEMENT SYSTEM  ");
            Console.WriteLine("=================================");
            Console.ResetColor();

            var bookService = new BookService();
            var memberService = new MemberService();
            var loanService = new LoanService(bookService, memberService);
            var reportService = new ReportService(bookService, memberService, loanService);
            var notificationService = new NotificationService();

            var author = new Author { Id = 1, Name = "George Orwell" };
            var book = new Book { Id = 1, Title = "1984", Author = author, IsAvailable = true };
            var member = new Member { Id = 1, Name = "John Doe" };

            bookService.AddBook(book);
            memberService.AddMember(member);

            if (loanService.LoanBook(1, 1))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                notificationService.SendLoanNotification(member, book);
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(reportService.GenerateSummary());
            Console.ResetColor();

            Console.WriteLine("=================================");
        }
    }
}
