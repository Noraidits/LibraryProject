using System.Dynamic;
using System.Threading.Tasks;
using TamrinApi.Interfaces;
using TamrinApi.Models;
using TamrinApi.Repositories;
using TamrinApi.Servises.InterFace;

namespace TamrinApi.Servises.models
{
    public class GettingBookService : IGettingBookService
    {
        private IMemberRepository _member;
        private IBookRepository _book;
        private IBorrowingRepository _borrowing;
        
        public GettingBookService(IMemberRepository member, IBookRepository book, IBorrowingRepository borrowing )
        {
            _member = member;
            _book = book;
            _borrowing = borrowing;
            
        }

        public async Task GetBookByMember(Guid memberId, Guid bookid)
        {
            if (_member.GetMemberById(memberId) == null) throw new Exception("your member is not exist");
            if (_book.getBookById(bookid) == null) throw new Exception("your book is not exist");
            if (!await _member.memberCanBorrow(memberId)) throw new Exception("you can't borrow book(expiring or full 5 book");
            if (!await _book.IsbookExisttoGet(bookid)) throw new Exception("your target book is not in library");

            await _book.Removeavaliblebook(bookid);
            await _member.addActiveBook(memberId);
        }
    }
}
