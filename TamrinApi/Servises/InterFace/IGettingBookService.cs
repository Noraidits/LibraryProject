using TamrinApi.Models;

namespace TamrinApi.Servises.InterFace
{
    public interface IGettingBookService
    {
        Task GetBookByMember(Guid memberId, Guid bookid);
    }
}
