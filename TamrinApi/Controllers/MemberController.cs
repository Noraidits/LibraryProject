using Microsoft.AspNetCore.Mvc;
using TamrinApi.Extensions;
using TamrinApi.Interfaces;
using TamrinApi.Models;
using TamrinApi.Models.DTOs;

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


        [HttpPost("addMember")]
        public IActionResult AddMember([FromBody] createMember memberDto) {

            Member member = new Member(memberDto.fullName, memberDto.email,memberDto.phoneNumber);

            _memberRepository.AddMember(member);
            return Created();
        }
        [HttpGet("All")]

        public IActionResult GetAll()
        {
            {
                return Ok(_memberRepository.GetAllMembers().Select(Member => Member.AsDto()));
            }
        }
        [HttpGet("{id}")]
        public IActionResult Getbyid(Guid id)
        {
            return Ok(_memberRepository.GetMemberById(id));
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
