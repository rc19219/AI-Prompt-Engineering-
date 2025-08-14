using LibraryApp.Models;

namespace LibraryApp.Services
{
    public class NotificationService
    {
        public void SendLoanNotification(Member member, Book book)
        {
            Console.WriteLine($"Notification: {member.Name} borrowed '{book.Title}'");
        }
    }
}
