using System.Data.SqlTypes;
using TamrinApi.Models;
using TamrinApi.Servises.InterFace;

namespace TamrinApi.Interfaces
{
    public interface IMemberRepository
    {
        public Member? GetMemberById(Guid id);
        public IEnumerable<Member>? GetMembersByName(string Name);
        public IEnumerable<Member> GetAllMembers();
        public void DeleteMemberById(Guid id);
        public void AddMember(Member member);
        public void UpdateMember(Member member, Guid id);
        public void AddTOExpieryDate (Guid id);
        public bool IsmemberActive(Guid Id);
        public void AddBorrow(Member member, Borrowing borow);
        public void RemoveBorrow(Member member,Guid BorrowId);
        //public void addActiveBook(Guid id);
        //public void removeActiveBook(Guid id);
        public uint getActiveBookCount(Guid Id);
        public bool memberCanBorrow(Guid Id);
    }
}
