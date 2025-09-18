using System.Data.SqlTypes;
using TamrinApi.Models;

namespace TamrinApi.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member?> GetMemberById(Guid id);
        Task<IEnumerable<Member>> GetMembersByName(string Name);
        Task<IEnumerable<Member>> GetAllMembers();
        Task DeleteMemberById(Guid id);
        Task AddMember(Member member);
        Task UpdateMember(Member member, Guid id);
        Task AddTOExpieryDate (Guid id);
        Task<bool> IsmemberActive(Guid Id);
        Task addActiveBook(Guid id);
        Task removeActiveBook(Guid id);
        Task<uint> getActiveBookCount(Guid Id);
        Task<bool> memberCanBorrow(Guid Id);
    }
}
