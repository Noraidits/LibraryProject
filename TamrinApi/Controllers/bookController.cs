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
        [HttpGet("{id}")]
        public IActionResult getBookById(Guid id)
        {
            var book = _bookRepository.getBookById(id);

            if (book == null) {
                return NotFound();
            }

            return Ok(book);
        }
    } 
}
