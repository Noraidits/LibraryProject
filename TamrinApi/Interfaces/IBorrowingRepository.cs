using System.Xml.Serialization;
using TamrinApi.Models;

namespace TamrinApi.Interfaces
{
    public interface IBorrowingRepository
    {
        Borrowing? GetBorrowingByid(Guid id);
        IEnumerable<Borrowing> GetAllborrowing();
        IEnumerable<Borrowing> GetBorrowByMember(Guid memberid);
        IEnumerable<Borrowing> GetBorrowByBook(Guid bookid);
        void addBorrow(Borrowing borrow);
        void updatereturndate (Guid id);
        void AddborrowingForservice(Guid memberId, Guid bookId);
    }

}
