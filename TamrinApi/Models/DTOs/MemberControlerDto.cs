namespace TamrinApi.Models.DTOs
{
    public record MemberDto(

        Guid id,
        string fullName,
        string email,
        string phoneNumber,
        DateOnly joinDate,
        DateOnly expiryDate,
        bool isActive,
        uint ActiveBook
    );

    public record createMember(

        string fullName,
        string email,
        string phoneNumber

    );

    public record Updatemember(

        string fullName,
        string email,
        string phoneNumber

    );




}


//Guid id,
//        string fullName,
//        string email,
//        string phoneNumber,
//        DateOnly joinDate,
//        DateOnly expiryDate,
//        bool isActive,
//        uint ActiveBook