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

        public BorrowController(IBorrowingRepository borrowingRepository)
        {
            //_getbookService = getbookService;
            _borrowingRepository = borrowingRepository;
            
        }

        [HttpPost("PostBorrow")]
        public IActionResult AddBorrow(Guid Memberid ,Guid Bookid)
        {
            //_getbookService.GetBookByMember(Memberid, Bookid);
            _borrowingRepository.AddborrowingForservice(Memberid, Bookid);
            return Ok();
        }


    }
}
