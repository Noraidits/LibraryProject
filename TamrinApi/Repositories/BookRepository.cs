using TamrinApi.Database;
using TamrinApi.DatabaseConnection;
using TamrinApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using TamrinApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TamrinApi.Models.DTOs;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDBContext _context;
    public BookRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task addBook(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    public async Task deleteBookById(Guid bookId)
    {
        var target = await _context.Books.FindAsync(bookId);
        if (target != null)
        {
            _context.Books.Remove(target);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Book>> getAllBooks()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book?> getBookById(Guid bookId)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.ID == bookId);
    }

    public async Task<IEnumerable<Book>> getBookByName(string bookName)
    {
        return await _context.Books
            .Where(k => k.title.Contains(bookName))
            .ToListAsync();
    }

    public async Task updateBook(UpdateBookDto book)
    {
        var targrt = await _context.Books.FindAsync(book.bookId);
        if (targrt == null) return;

        var diffrence = book.totalCopies - targrt.totalCopies;
        if(diffrence > 0 && targrt.availabaleCopies + (uint)Math.Abs(diffrence) < uint.MaxValue)
        {
            targrt.availabaleCopies += (uint)Math.Abs(diffrence);
        }else if(diffrence < 0 && targrt.availabaleCopies + (uint)Math.Abs(diffrence) > uint.MinValue)
        {
            targrt.availabaleCopies -= (uint)Math.Abs(diffrence);
        }
        else
        {
            throw new Exception("availabaleCopies cant be smaller then 0 or larger then uint.MaxValue");
        }


        targrt.totalCopies = book.totalCopies;


        await _context.SaveChangesAsync();
    }

    public async Task removeCopy(Guid ID, uint number)
    {
        var target = await getBookById(ID);
        if(target != null && target.availabaleCopies > 0)
        {
            target.availabaleCopies --;
            await _context.SaveChangesAsync();
        }
    }

    public async Task addCopy(Guid ID, uint number)
    {
        var target = await getBookById(ID);
        if (target != null && target.availabaleCopies <= 5)
        {
            target.totalCopies--;
            await _context.SaveChangesAsync();
        }

    }

    public async Task<bool> IsbookExisttoGet(Guid id)
    {
        var target = await getBookById(id);

        return target != null && (target.availabaleCopies > 0);

    }

    public async Task Removeavaliblebook(Guid id)
    {
        var target =await getBookById(id);
        if (target != null)
        {
            target.availabaleCopies -= 1;
            await _context.SaveChangesAsync();
        }
    }

    public async Task Addavaleblebook(Guid id)
    {
        var target =await getBookById(id);
        if (target != null)
        {
            target.availabaleCopies += 1;
            await _context.SaveChangesAsync();
        }
    }
}
