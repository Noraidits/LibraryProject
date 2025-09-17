using System.Dynamic;
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
        public GettingBookService(IMemberRepository member, IBookRepository book)
        {
            _member = member;
            _book = book;
        }

        public void GetBookByMember(Guid memberId, Guid bookid)
        {
            if (_member.GetMemberById(memberId) == null) throw new Exception("your member is not exist");
            if (_book.getBookById(bookid) == null) throw new Exception("your book is not exist");
            if (!_member.memberCanBorrow(memberId)) throw new Exception("you can't borrow book(expiring or full 5 book");
            if (!_book.IsbookExisttoGet(bookid)) throw new Exception("your target book is not in library");

            _book.Removeavaliblebook(bookid);
            _member.addActiveBook(memberId);
        }
    }
}
