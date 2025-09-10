using TamrinApi.Interfaces;
using TamrinApi.Models;
using TamrinApi.Database;

namespace TamrinApi.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public Member? GetMemberById(Guid id)
        {
            return MemberDataBase.members.SingleOrDefault(c => c.id == id);
        }
        public void AddMember(Member member)
        {
            MemberDataBase.members.Add(member);
        }

        public void ExtensionExpieryDate(Guid id)
        {
            var target = GetMemberById(id);
            if (!target.isActive)
            {
                target.expiryDate = DateOnly.FromDateTime(DateTime.Now).AddDays(180);
            }
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return MemberDataBase.members;
        }


        public IEnumerable<Member> GetMembersByName(string Name)
        {
            IEnumerable<Member> result = MemberDataBase.members.Where(M => M.fullName.Contains(Name));
            return result;
        }

        public void UpdateMember(Member member,Guid id)
        {
            var target = GetMemberById(id);

            target.email = member.email;
            target.phoneNumber = member.phoneNumber;

        }

        void IMemberRepository.DeleteMemberById(Guid id)
        {
            var target = GetMemberById(id);
            MemberDataBase.members.Remove(target);
        }

        public bool IsmemberActive(Guid Id)
        {
            var target = GetMemberById(Id);

            return target.isActive;
        }
    }
}
