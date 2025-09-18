using System.Net;
using Microsoft.EntityFrameworkCore;
using TamrinApi.Database;
using TamrinApi.DatabaseConnection;
using TamrinApi.Interfaces;
using TamrinApi.Models;

namespace TamrinApi.Repositories
{
    public class BorrowingRepository : IBorrowingRepository
    {
        private readonly ApplicationDBContext _context;
        public BorrowingRepository(ApplicationDBContext context)
        {
            _context = context;
        }


        public async Task<Borrowing?> GetBorrowingByid(Guid id)
        {
            return await _context.Borrowings.FirstOrDefaultAsync(b => b.id == id);
        }

        public async Task<IEnumerable<Borrowing>> GetBorrowByBook(Guid boookid)
        {
            return await _context.Borrowings.Where(c => c.bookid == boookid).ToListAsync();
        }

        public async Task<IEnumerable<Borrowing>> GetBorrowByMember(Guid memberid)
        {
            return await _context.Borrowings.Where(c => c.memberid == memberid).ToListAsync();
        }


        public async Task updatereturndate(Guid id)
        {
            var target = await GetBorrowingByid(id);
            
            if(target != null && target.returnDate == DateOnly.MinValue)
            {
                target.returnDate = DateOnly.FromDateTime(DateTime.Now);
                await _context.SaveChangesAsync();
            }
        }

        public async Task addBorrow(Borrowing borrow)
        {
            await _context.Borrowings.AddAsync(borrow);
            await _context.SaveChangesAsync();
        }

        public async Task AddborrowingForservice(Guid memberId, Guid bookId)
        {
            Borrowing borrowing = new Borrowing(bookId, memberId);
                         
            await addBorrow(borrowing);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Borrowing>> GetAllborrowing()
        {
            return await _context.Borrowings.ToListAsync();
        }
    }
}
