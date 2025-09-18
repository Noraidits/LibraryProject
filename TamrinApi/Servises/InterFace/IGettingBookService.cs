using TamrinApi.Models;

namespace TamrinApi.Servises.InterFace
{
    public interface IGettingBookService
    {
        public void GetBookByMember(Guid memberId, Guid bookid, Borrowing borrowing);
        public void ReturnBook(Member member, Guid bookId);
    }
}
