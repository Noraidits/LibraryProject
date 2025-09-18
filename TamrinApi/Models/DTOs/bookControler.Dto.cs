namespace TamrinApi.Models.DTOs
{
    //  string titel, string auther, string categoty, uint publishedYear, uint totalCopies, uint availabaleCopies
    public record bookDto(
         Guid bookId,
         string titel,
         string auther,
         string categoty,
         uint publishedYear,
         uint totalCopies,
         uint availabaleCopies
    );
    public record PostBookDto(
        string titel,
        string auther,
        string categoty,
        uint publishedYear,
        uint totalCopies
   );
    public record UpdateBookDto(
        Guid bookId,
        uint totalCopies
        );


}

