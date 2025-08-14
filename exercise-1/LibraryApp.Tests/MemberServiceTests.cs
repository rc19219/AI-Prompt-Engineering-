using LibraryApp.Models;
using LibraryApp.Services;
using Xunit;

namespace LibraryApp.Tests
{
    public class MemberServiceTests
    {
        [Fact]
        public void AddMember_ShouldAddMemberSuccessfully()
        {
            var service = new MemberService();
            var member = new Member { Id = 1, Name = "John" };

            service.AddMember(member);
            var retrieved = service.GetMember(1);

            Assert.NotNull(retrieved);
            Assert.Equal("John", retrieved.Name);
        }
    }
}
