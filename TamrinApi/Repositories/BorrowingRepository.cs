using TamrinApi.Database;
using TamrinApi.Interfaces;
using TamrinApi.Models;

namespace TamrinApi.Repositories
{
    public class BorrowingRepository : IBorrowingRepository
    {
        public void addBorrow(Borrowing borrow)
        {
            BorrowDatabase.borrowings.Add(borrow);
        }
        public Borrowing? GetBorrowingByid(Guid id)
        {
            return BorrowDatabase.borrowings.SingleOrDefault(c => c.id == id);
        }

        public IEnumerable<Borrowing> GetBorrowByBook(Guid boookid)
        {
            IEnumerable<Borrowing> result = BorrowDatabase.borrowings.Where(c => c.bookid == boookid);
            return result;
        }

        public IEnumerable<Borrowing> GetBorrowByMember(Guid memberid)
        {
            IEnumerable<Borrowing> result = BorrowDatabase.borrowings.Where(c => c.memberid == memberid);
            return result;
        }


        public void updatereturndate(DateOnly returndaate,Guid id)
        {
            var target = GetBorrowingByid(id);

            target.returnDate = returndaate;
        }
    }
}
