using Microsoft.AspNetCore.Mvc;
using TamrinApi.Interfaces;

namespace TamrinApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MemberController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            {
                return Ok(_memberRepository.GetAllMembers());
            }
        }
        [HttpGet("{id}")]
        public IActionResult Getbyid(Guid id)
        {
            return Ok(_memberRepository.GetMemberById(id));
        }
    }
}
