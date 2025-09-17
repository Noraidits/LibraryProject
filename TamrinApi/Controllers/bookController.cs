using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
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
        public IActionResult addBook([FromBody] bookDto bookDto)
        {

            Book book = new Book(bookDto.titel, bookDto.auther, bookDto.categoty, bookDto.publishedYear, bookDto.totalCopies);

            _bookRepository.addBook(book);
            return Ok(book);
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookRepository.getAllBooks();
            return Ok(books);
        }

        [HttpGet ("{BookId}")]
        public IActionResult getBookById(Guid id)
        {
            var book = _bookRepository.getBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("{BookName}")]
        public IActionResult getBookByname(string name)
        {
            var books = _bookRepository.getBookByName(name);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }


        [HttpPut]
        public IActionResult updateBook([FromBody] Book book)
        {
            if (_bookRepository.getBookById(book.ID) != null)
            {
                _bookRepository.updateBook(book);
                return Ok();
            }
            else return BadRequest("Id is not find");
        }
        [HttpPut("removeCopy")]
        public IActionResult addCopy(Guid ID, uint number)
        {
            if (_bookRepository.getBookById(ID) != null)
            {
                _bookRepository.removeCopy(ID, number);
                return Ok();
            }
            else return BadRequest("Id is not find");
        }

        [HttpPut("addCopyBook")]

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
        public IActionResult actionResult(Guid id)
        {
            if (_bookRepository.getBookById(id) == null) return NoContent();
            _bookRepository.deleteBookById(id);
            return Ok();
        }


    }
}
