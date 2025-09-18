using System.Xml.Serialization;
using TamrinApi.Models;

namespace TamrinApi.Interfaces
{
    public interface IBorrowingRepository
    {
        Task<Borrowing?> GetBorrowingByid(Guid id);
        Task<IEnumerable<Borrowing>> GetAllborrowing();
        Task<IEnumerable<Borrowing>> GetBorrowByMember(Guid memberid);
        Task<IEnumerable<Borrowing>> GetBorrowByBook(Guid bookid);
        Task addBorrow(Borrowing borrow);
        Task updatereturndate (Guid id);
        Task AddborrowingForservice(Guid memberId, Guid bookId);
    }

}
