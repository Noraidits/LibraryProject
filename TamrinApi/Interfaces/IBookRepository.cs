using TamrinApi.Models;
namespace TamrinApi.Interfaces

{
    public interface IBookRepository
    {
        Book getBookById(Guid bookId);
        IEnumerable<Book> getBookByName(string bookName);
        IEnumerable<Book> getAll();
        void deleteBookById(Guid bookId);
        void addBook(Book book);
        void updateBook(Book book);
        void addCopy(Book book,Guid ID);
        void removeCopy(Book book, Guid ID);


    }
}
