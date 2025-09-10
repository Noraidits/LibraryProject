using System.Net;
using TamrinApi.Database;
using TamrinApi.Interfaces;
using TamrinApi.Models;

namespace TamrinApi.Repositories
{
    public class BookRepository : IBookRepository
    {
         void addBook(Book book)
        {
            bookDataBase.books.Add(book);
        }


         void deleteBookById(Guid bookId)
        {
            bookDataBase.books.RemoveAll(b => b.ID == bookId);
        }

        IEnumerable<Book> getAllBooks()
        {
            return bookDataBase.books;
        }

        Book? getBookById(Guid bookId)
        {
            return bookDataBase.books.SingleOrDefault(c => c.ID == bookId);
        }

        IEnumerable<Book>? getBookByName(string bookName)
        {
            return bookDataBase.books.Where(b => b.titel == bookName);
        }

       

        void updateBook(Book book)
        {
            
            var target = getBookById(book.ID);
            target = book;
            
        }
        void removeCopy(Book book, Guid ID)
        {
            throw new NotImplementedException();
        }

        void addCopy(Book book, Guid ID)
        {

        }

    }
}

