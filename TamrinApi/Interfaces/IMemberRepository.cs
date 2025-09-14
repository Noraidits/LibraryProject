using System.Data.SqlTypes;
using TamrinApi.Models;

namespace TamrinApi.Interfaces
{
    public interface IMemberRepository
    {
        Member? GetMemberById(Guid id);
        IEnumerable<Member>? GetMembersByName(string Name);
        IEnumerable<Member> GetAllMembers();
        void DeleteMemberById(Guid id);
        void AddMember(Member member);
        void UpdateMember(Member member, Guid id);
        void AddTOExpieryDate (Guid id);
        bool IsmemberActive(Guid Id);
        void addActiveBook(Guid id);
        void removeActiveBook(Guid id);
        uint getActiveBookCount(Guid Id);
        bool memberCanBorrow(Guid Id);
    }
}
