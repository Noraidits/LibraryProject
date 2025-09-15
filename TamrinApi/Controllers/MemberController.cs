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
        [HttpPut("addTOExoyeryDate")]
        public IActionResult AddToAddTOExpieryDate( Guid Id)
        {
            _memberRepository.AddTOExpieryDate(Id);
            return Created();
        }
        [HttpPut("updateMember")]
        public IActionResult UpdateMember([FromBody] Member member,Guid id)
        {

            _memberRepository.UpdateMember(member,id);
            return Ok();
        }
        [HttpGet("getAll")]

        public IActionResult GetAll()
        {
            {
                return Ok(_memberRepository.GetAllMembers().Select(Member => Member.AsDto()));
            }
        }
        [HttpGet("byID{id}")]
        public IActionResult Getbyid(Guid id)
        {
            return Ok(_memberRepository.GetMemberById(id));
        }
        [HttpGet("getActiveBookCount{Id}")]
        public IActionResult getBookCount(Guid Id)
        {
            return Ok(_memberRepository.getActiveBookCount(Id));
        }

  
        [HttpDelete]
        public IActionResult deleteById(Guid id) {
            if (_memberRepository.GetMemberById(id) == null) return NoContent();
            _memberRepository.DeleteMemberById(id);
            return Ok(); 
        }
    }
}