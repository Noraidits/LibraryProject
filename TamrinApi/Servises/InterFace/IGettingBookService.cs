namespace TamrinApi.Servises.InterFace
{
    public interface IGettingBookService
    {
        void GetBookByMember(Guid memberId, Guid bookid);
    }
}
