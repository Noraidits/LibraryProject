using System.Dynamic;
using TamrinApi.Interfaces;
using TamrinApi.Models;
using TamrinApi.Repositories;

namespace TamrinApi.Servises
{
    public class GettingBookService
    {
        private MemberRepository _member;
        private BookRepository _book;


        public void GetBookByMember(Guid memberId, Guid bookid)
        {
            if (_member.GetMemberById(memberId) == null) throw new Exception("your member is not exist");
            if (_book.getBookById(bookid) == null) throw new Exception("your book is not exist");
            if (_member.memberCanBorrow(bookid)) throw new Exception("you can't borrow book(expiring or full 5 book");
            if (_book.IsbookExisttoGet(bookid)) throw new Exception("your target book is not in library");
            
            _book.removeCopy(bookid,1);
            _member.addActiveBook(memberId);
        }
    }
}
