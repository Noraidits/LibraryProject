using TamrinApi.Models;
namespace TamrinApi.Interfaces

{
    public interface IBookRepository
    {
        
       public Book? getBookById(Guid bookId);
        
       public IEnumerable<Book> getBookByName(string bookName);
        
       public IEnumerable<Book> getAllBooks();
        
       public void deleteBookById(Guid bookId);
        
       public void addBook(Book book);
        
       public void updateBook(Book book);
        
       public void addCopy(Guid ID, uint number);
        
       public void removeCopy(Guid ID, uint number);

       public bool IsbookExisttoGet(Guid id);
    }
}
