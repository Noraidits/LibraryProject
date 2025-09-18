using System.Net;
using TamrinApi.Database;
using TamrinApi.Interfaces;
using TamrinApi.Models;

namespace TamrinApi.Repositories
{
    public class BorrowingRepository : IBorrowingRepository
    {
        

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


        public void updatereturndate(Guid id)
        {
            var target = GetBorrowingByid(id);
            if (target == null) throw new Exception("you didnt have that borowing");

            target.returnDateSeter();
        }

        public void addBorrow(Borrowing borrow)
        {
            Database.BorrowDatabase.borrowings.Add(borrow);
        }

        public void AddborrowingForservice(Guid memberId, Guid bookId)
        {
            Borrowing borrowing = new Borrowing(bookId, memberId);
                         
            addBorrow(borrowing);

        }

        public IEnumerable<Borrowing> GetAllborrowing()
        {
            return Database.BorrowDatabase.borrowings; 
        }
    }
}
