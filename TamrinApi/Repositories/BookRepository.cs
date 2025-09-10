using System.Net;
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

        IEnumerable<Book> IBookRepository.getAllBooks()
        {
            return bookDataBase.books;
        }

        Book? getBookById(Guid bookId)
        {
            return bookDataBase.books.SingleOrDefault(c => c.ID == bookId);
        }

        IEnumerable<Book>? IBookRepository.getBookByName(string bookName)
        {
            return bookDataBase.books.Where(b => b.titel == bookName);
        }

       

        void IBookRepository.updateBook(Book book)
        {
            
            var target = getBookById(book.ID);
            target = book;
            
        }
        void IBookRepository.removeCopy(Book book, Guid ID)
        {
            throw new NotImplementedException();
        }

        void IBookRepository.addCopy(Book book, Guid ID)
        {

        }

    }
}

