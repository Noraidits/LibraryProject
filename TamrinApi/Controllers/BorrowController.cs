using Microsoft.AspNetCore.Mvc;
using TamrinApi.Interfaces;
using TamrinApi.Models;
using TamrinApi.Repositories;
using TamrinApi.Servises;

namespace TamrinApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class BorrowController : ControllerBase
    {

        private readonly IBorrowingRepository _borrowingRepository;
        private readonly IGettingBookService _gettingBookService;

        public BorrowController(IBorrowingRepository borrowingRepository, IGettingBookService gettingBookService)
        {

            _borrowingRepository = borrowingRepository;
            _gettingBookService = gettingBookService;
        }

        [HttpPost("PostBorrow")]
        public IActionResult AddBorrow(Guid Memberid, Guid Bookid)
        {
            _gettingBookService.GetBookByMember(Memberid, Bookid);
            Borrowing borrowing = new Borrowing(Memberid, Bookid);
            _borrowingRepository.addBorrow(borrowing);
            return Ok(borrowing);
        }

        [HttpGet("getbBarrowById")]
        public IActionResult GetAll(Guid Id)
        {
            return Ok(_borrowingRepository.GetBorrowingByid(Id));
        }

        [HttpPatch]
        public IActionResult setReturnDate(Guid Id)
        {
            _borrowingRepository.updatereturndate(Id);
            return NoContent();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_borrowingRepository.GetAllborrowing());
        }

    }
}
