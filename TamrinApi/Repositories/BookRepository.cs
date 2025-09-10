using TamrinApi.Database;
using TamrinApi.Interfaces;
using TamrinApi.Models;

namespace TamrinApi.Repositories
{
    public class BookRepository : IBookRepository
    {
         void IBookRepository.addBook(Book book)
        {
            bookDataBase.books.Add(book);
        }


         void IBookRepository.deleteBookById(Guid bookId)
        {
            bookDataBase.books.RemoveAll(b => b.ID == bookId);
        }

        IEnumerable<Book> IBookRepository.getAll()
        {
            throw new NotImplementedException();
        }

        Book? IBookRepository.getBookById(Guid bookId)
        {
            return bookDataBase.books.SingleOrDefault(c => c.ID == bookId);
        }

        IEnumerable<Book> IBookRepository.getBookByName(string bookName)
        {
            
        }

        void IBookRepository.removeCopy(Book book, Guid ID)
        {
            throw new NotImplementedException();
        }

        void IBookRepository.updateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}

