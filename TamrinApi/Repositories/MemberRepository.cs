using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using TamrinApi.Database;
using TamrinApi.DatabaseConnection;
using TamrinApi.Interfaces;
using TamrinApi.Models;

namespace TamrinApi.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDBContext _context;
        public MemberRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Member?> GetMemberById(Guid MemberId)
        {
            return await _context.Members.FirstOrDefaultAsync(k => k.id == MemberId);
        }
        public async Task AddMember(Member member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task AddTOExpieryDate(Guid id)
        {
            var target = await GetMemberById(id);

            if (target != null && target.isActive)
            {
                target.expiryDate = DateOnly.FromDateTime(DateTime.Now).AddDays(180);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            return await _context.Members.ToListAsync();
        }


        public async Task<IEnumerable<Member>> GetMembersByName(string Name)
        {
            return await _context.Members
                .Where(k => k.fullName.Contains(Name))
                .ToListAsync();
        }

        public async Task UpdateMember(Member member, Guid id)
        {
            var target = await GetMemberById(id);
            if (target == null) throw new Exception("your member is not exist");
            _context.Members.Update(member);
            await _context.SaveChangesAsync();

        }

        public void AddBorrow(Member member, Borrowing borow)
        {
            member.AddBorrow(borow);
        }
        public void RemoveBorrow(Member member, Guid BorrowId)
        {
            member.RemoveBorrow(BorrowId);
        }

        public async Task DeleteMemberById(Guid id)
        {
            var target = await GetMemberById(id);
            if (target != null)
            {
                _context.Members.Remove(target);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsmemberActive(Guid Id)
        {
            var target = await GetMemberById(Id);
            if (target != null && target.isActive) return true;
            else return false;

        }

        public async Task addActiveBook(Guid id)
        {
            var target = await GetMemberById(id);
            if (target != null)
            {
                target.ActiveBook++;
                await _context.SaveChangesAsync();
            }

        }

        public async Task removeActiveBook(Guid id)
        {
            var target = await GetMemberById(id);
            if (target != null)
            {
                target.ActiveBook--;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<uint> getActiveBookCount(Guid Id)
        {
            var target =await GetMemberById(Id);
            return target.ActiveBook;
            
        }

        public async Task<bool> memberCanBorrow(Guid Id)
        {
            var target = await GetMemberById(Id);

            if (!target.isActive)
            {
                return false;
            }
            else if (DateOnly.FromDateTime(DateTime.Now) >= target.expiryDate)
            {
                target.changeIsActive(false);
                return false;
            }
            else if (target.ActiveBook >= 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
