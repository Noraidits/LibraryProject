using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using TamrinApi.Interfaces;
using TamrinApi.Models;
using TamrinApi.Models.DTOs;

namespace TamrinApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class bookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public bookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost]
        public IActionResult addBook([FromBody] PostBookDto bookDto)
        {


            Book book = new Book(bookDto.titel, bookDto.auther, bookDto.categoty, bookDto.publishedYear, bookDto.totalCopies);

            _bookRepository.addBook(book);
            return Ok(book);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {

            var books = await _bookRepository.getAllBooks();
            return Ok(books);

        }

        [HttpGet("{BookId}")]
        public async Task<IActionResult> getBookById(Guid id)
        {
            var book = await _bookRepository.getBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("{BookName}")]
        public async Task<IActionResult> getBookByname(string name)
        {
            var books = await _bookRepository.getBookByName(name);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }


        [HttpPut]
        public async Task<IActionResult> updateBook([FromBody] UpdateBookDto book)
        {
            if (await _bookRepository.getBookById(book.bookId) != null)
            {
                await _bookRepository.updateBook(book);
                return Ok();
            }
            else return BadRequest("Id is not find");
        }


        [HttpPut("{AvalibleCopy}/add")]
        public async Task<IActionResult> addCopy(Guid ID, uint number)
        {
            if (await _bookRepository.getBookById(ID) != null)
            {
                await _bookRepository.removeCopy(ID, number);
                return Ok();
            }
            else return BadRequest("Id is not find");
        }

        [HttpPut("{AvalibleCopy}/remove")]

        public IActionResult addcopy(Guid ID, uint number)
        {
            if (_bookRepository.getBookById(ID) != null)
            {
                _bookRepository.addCopy(ID, number);
                return Ok();
            }
            else return BadRequest("Id is not find");
        }



        [HttpDelete]

        public IActionResult DeleteBook(Guid id)
        {
            if (_bookRepository.getBookById(id) == null) return NoContent();
            _bookRepository.deleteBookById(id);
            return Ok();
        }


    }
}
