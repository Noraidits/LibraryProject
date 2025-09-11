using TamrinApi.Database;
using TamrinApi.Interfaces;
using TamrinApi.Models;

public class BookRepository : IBookRepository
{
    public void addBook(Book book)
    {
        bookDataBase.books.Add(book);
    }

    public void deleteBookById(Guid bookId)
    {
        bookDataBase.books.RemoveAll(b => b.ID == bookId);
    }

    public IEnumerable<Book> getAllBooks()
    {
        return bookDataBase.books;
    }

    public Book? getBookById(Guid bookId)
    {
        return bookDataBase.books.SingleOrDefault(c => c.ID == bookId);
    }

    public IEnumerable<Book>? getBookByName(string bookName)
    {
        return bookDataBase.books.Where(b => b.titel == bookName);
    }

    public void updateBook(Book book)
    {
        var target = getBookById(book.ID);
        if (target != null) {
            target.titel = book.titel;
            target.auther = book.auther;
            target.categoty = book.categoty;
            target.publishedYear = book.publishedYear;
            target.totalCopies = book.totalCopies;
            target.availabaleCopies = book.availabaleCopies;
        }
    }

    public void removeCopy(Guid ID, uint number)
    {
        var target = getBookById(ID);
        if (target != null) {
            target.totalCopies -= number;
        }
    }

    public void addCopy(Guid ID, uint number)
    {
        var target = getBookById(ID);
        if (target != null) {
            target.totalCopies -= number;
        }

    }
}
