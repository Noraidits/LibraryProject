namespace TamrinApi.Models.DTOs
{
    //  string titel, string auther, string categoty, uint publishedYear, uint totalCopies, uint availabaleCopies
    public record bookDto(
         string titel,
         string auther,
         string categoty,
         uint publishedYear,
         uint totalCopies,
         uint availabaleCopies
    );
    public record getBookDto(
        Guid ID,
        string titel,
        string auther,
        string categoty,
        uint publishedYear,
        uint totalCopies,
        uint availabaleCopies
   );
}

