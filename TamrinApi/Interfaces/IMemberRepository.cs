using TamrinApi.Models;

namespace TamrinApi.Interfaces
{
    public interface IMemberRepository
    {
        Member? GetMemberById(Guid id);
        IEnumerable<Member> GetMembersByName(string Name);
        IEnumerable<Member> GetAllMembers();
        void DeleteMemberById(Guid id);
        void AddMember(Member member);
        void UpdateMember(Member member, Guid id);
        void ExtensionExpieryDate (Guid id);
        bool IsmemberActive(Guid Id);

    }
}
