using Microsoft.AspNetCore.Mvc;
using TamrinApi.Interfaces;
using TamrinApi.Models;

namespace TamrinApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class bookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public bookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpPost("add book")]
        public IActionResult addBook([FromBody] Book book)
        {
            _bookRepository.addBook(book);
            return Created();
        }



        [HttpGet("getById {id}")]
        public IActionResult getBookById(Guid id)
        {
            var book = _bookRepository.getBookById(id);

            if (book == null) {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("getByName {name}")]
        public IActionResult getBookByname(string name)
        {
            var books = _bookRepository.getBookByName(name);

            if (books == null) {
                return NotFound();
            }

            return Ok(books);
        }


        [HttpGet("getAll")]
        public IActionResult GetAllBooks()
        {
            var books = _bookRepository.getAllBooks();
            return Ok(books);
        }

    }
}
