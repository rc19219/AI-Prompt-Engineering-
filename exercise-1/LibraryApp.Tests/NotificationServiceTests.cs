using LibraryApp.Models;
using LibraryApp.Services;
using Xunit;
using System.IO;

namespace LibraryApp.Tests
{
    public class NotificationServiceTests
    {
        [Fact]
        public void SendLoanNotification_ShouldWriteToConsole()
        {
            var notificationService = new NotificationService();
            var member = new Member { Id = 1, Name = "John" };
            var book = new Book { Id = 1, Title = "Test Book" };

            using var sw = new StringWriter();
            Console.SetOut(sw);

            notificationService.SendLoanNotification(member, book);

            var output = sw.ToString().Trim();
            Assert.Contains("Notification: John borrowed 'Test Book'", output);
        }
    }
}
