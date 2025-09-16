using TamrinApi.Database;
using TamrinApi.Interfaces;
using TamrinApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    public Book? getBookById(Guid bookId) => bookDataBase.books.SingleOrDefault(c => c.ID == bookId);

    public IEnumerable<Book>? getBookByName(string bookName)
    {
        return bookDataBase.books.Where(b => b.title==(bookName));
    }

    public void updateBook(Book book)
    {
        var target = getBookById(book.ID);
        if (target != null) {
            target.title = book.title;
            target.auther = book.auther;
            target.category = book.category;
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
            target.totalCopies += number;
        }

    }

    public bool IsbookExisttoGet(Guid id)
    {
        var target = getBookById(id);

        return target != null && target.availabaleCopies > 0;
        
    }

    public void Removeavaliblebook(Guid id)
    {
        var target = getBookById(id);
        if (target != null)
        {
            target.availabaleCopies -= 1;
        }
    }

    public void Addavaleblebook(Guid id)
    {
        var target = getBookById(id);
        if (target != null)
        {
            target.availabaleCopies += 1;
        }
    }
}
