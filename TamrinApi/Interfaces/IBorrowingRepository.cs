using System.Xml.Serialization;
using TamrinApi.Models;

namespace TamrinApi.Interfaces
{
    public interface IBorrowingRepository
    {
        public Borrowing? GetBorrowingByid(Guid id);
        public IEnumerable<Borrowing> GetAllborrowing();
        public IEnumerable<Borrowing> GetBorrowByMember(Guid memberid);
        public IEnumerable<Borrowing> GetBorrowByBook(Guid bookid);
        public void addBorrow(Borrowing borrow);
        public void updatereturndate (Guid id);
        public void AddborrowingForservice(Guid memberId, Guid bookId);
    }

}
