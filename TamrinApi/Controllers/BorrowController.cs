using Microsoft.AspNetCore.Mvc;
using TamrinApi.Interfaces;
using TamrinApi.Models;
using TamrinApi.Repositories;
using TamrinApi.Servises.InterFace;

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

        [HttpPost]
        public IActionResult AddBorrow(Guid Memberid, Guid Bookid,Borrowing borrowing)
        {
            _gettingBookService.GetBookByMember(Memberid, Bookid,borrowing);
            //Borrowing borrowing = new Borrowing(Memberid, Bookid);
            _borrowingRepository.addBorrow(borrowing);
            return Ok(borrowing);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_borrowingRepository.GetAllborrowing());
        }

        [HttpGet("{BorrowId}")]
        public IActionResult GetAll(Guid Id)
        {
            return Ok(_borrowingRepository.GetBorrowingByid(Id));
        }

        [HttpPatch("{BarrowId}/ReturnDate")]
        public IActionResult setReturnDate(Guid BarrowId)
        {
            _borrowingRepository.updatereturndate(BarrowId);
            return NoContent();
        }


    }
}
