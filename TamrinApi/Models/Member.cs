using System.Globalization;

namespace TamrinApi.Models
{
    public class Member : Person
    {
        public Member(Guid id, string fullName, string email, string phoneNumber,DateOnly joinDate,DateOnly expiryDate, bool isActive = true,uint ActiveBook = 0) : base(id, fullName, email, phoneNumber)
        {
            id = Guid.NewGuid();
            this.id = id;
            joinDate = DateOnly.FromDateTime(DateTime.Now);
            expiryDate = setExpiryDate(joinDate);
        }

        public DateOnly joinDate { get; init; }
        public DateOnly expiryDate { get; set; }
        public bool isActive { get; set; }
        public uint ActiveBook { get; set; }

        public DateOnly setExpiryDate(DateOnly JoinDate)
        {
            return JoinDate.AddDays(180);
        }
    }
}
