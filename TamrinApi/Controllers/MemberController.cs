using Microsoft.AspNetCore.Mvc;
using TamrinApi.Interfaces;
using TamrinApi.Models;

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

        [HttpPost]
        public IActionResult AddMember([FromBody] Member member)
        {
            _memberRepository.AddMember(member);
            return Created();
        }
    }
}
