using System.Xml.Serialization;
using TamrinApi.Models;

namespace TamrinApi.Interfaces
{
    public interface IBorrowingRepository
    {
        Borrowing? GetBorrowingByid(Guid id);
        IEnumerable<Borrowing> GetBorrowByMember(Guid memberid);
        IEnumerable<Borrowing> GetBorrowByBook(Guid bookid);
        void addBorrow(Borrowing borrow);
        void updatereturndate (DateOnly returndaate, Guid id);
        void AddborrowingForservice(Guid memberId, Guid bookId);
    }

}
