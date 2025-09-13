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

        [HttpGet("All")]
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

        [HttpPost("addMember")]
        public IActionResult AddMember([FromBody] Member member)
        {
            _memberRepository.AddMember(member);
            return Created();
        }
        [HttpPut("addTOExoyeryDate")]
        public IActionResult AddToAddTOExpieryDate( Guid Id)
        {
            _memberRepository.AddTOExpieryDate(Id);
            return Created();
        }
        [HttpPut("updateMember")]
        public IActionResult UpdateMember([FromBody] Member member)
        {
            _memberRepository.UpdateMember(member,member.id);
            return Ok();
        }
    }
}
