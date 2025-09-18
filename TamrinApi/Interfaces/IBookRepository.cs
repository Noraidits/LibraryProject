using TamrinApi.Models;
using TamrinApi.Models.DTOs;
namespace TamrinApi.Interfaces

{
    public interface IBookRepository
    {
        
       public Task<Book?> getBookById(Guid bookId);
        
       public Task<IEnumerable<Book>?> getBookByName(string bookName);
        
       public Task<IEnumerable<Book>> getAllBooks();
        
       public Task deleteBookById(Guid bookId);
        
       public Task addBook(Book book);
        
       public Task updateBook(UpdateBookDto book);
        
       public Task addCopy(Guid ID, uint number);
        
       public Task removeCopy(Guid ID, uint number);

       public Task<bool> IsbookExisttoGet(Guid id);

        public Task Removeavaliblebook(Guid id);
        public Task Addavaleblebook(Guid id);
    }
}
