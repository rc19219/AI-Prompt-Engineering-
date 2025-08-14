using LibraryApp.Models;

namespace LibraryApp.Services
{
    public class MemberService
    {
        private readonly List<Member> members = new();

        public void AddMember(Member member) => members.Add(member);
        public Member GetMember(int id) => members.FirstOrDefault(m => m.Id == id);
        public IEnumerable<Member> GetAllMembers() => members;
    }
}
