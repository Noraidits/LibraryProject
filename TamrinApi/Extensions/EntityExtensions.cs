using TamrinApi.Models;
using TamrinApi.Models.DTOs;

namespace TamrinApi.Extensions
{
    public static class EntityExtensions
    {
        public static MemberDto AsDto(this Member member)
        {

            return new MemberDto(
            member.id,
            member.fullName,
            member.email,
            member.phoneNumber,
            member.joinDate,
            member.expiryDate,
            member.isActive,
            member.ActiveBook

            );
        }
        public static bookDto AsDto(this Book book)
        {

            return new bookDto(
                book.ID,
                book.titel,
                book.auther,
                book.categoty,
                book.publishedYear,
                book.totalCopies,
                book.availabaleCopies

            );

        }

    }
}

//Guid id,
//        string fullName,
//        string email,
//        string phoneNumber,
//        DateOnly joinDate,
//        DateOnly expiryDate,
//        bool isActive,
//        uint ActiveBook