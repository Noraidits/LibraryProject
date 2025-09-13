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

        [HttpGet]
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

        [HttpPost]
        public IActionResult AddMember([FromBody] createMember memberDto)
        {
            Member member = new()
            {   
                fullName = memberDto.fullName,
                email = memberDto.email,
                phoneNumber = memberDto.phoneNumber
            };

            _memberRepository.AddMember(member);
            return Created();
        }
    }
}
