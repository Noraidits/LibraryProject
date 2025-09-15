namespace TamrinApi.Servises
{
    public interface IGettingBookService
    {
        void GetBookByMember(Guid memberId, Guid bookid);
    }
}
