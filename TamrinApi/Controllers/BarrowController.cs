using Microsoft.AspNetCore.Mvc;
using TamrinApi.Models;
using TamrinApi.Repositories;
using TamrinApi.Servises;

namespace TamrinApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class BorrowController : ControllerBase
    {
        private readonly GettingBookService _getbookService;
        private readonly BorrowingRepository _borrowingRepository;

        [HttpPost("PostBorrow")]
        public IActionResult AddBorrow(Guid Memberid ,Guid Bookid)
        {
            _getbookService.GetBookByMember(Memberid,Bookid);
            Borrowing borrow = new Borrowing(Bookid,Memberid);
            _borrowingRepository.addBorrow(borrow);
            return Ok(borrow);
        }
    }
}
