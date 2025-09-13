using System.Globalization;

namespace TamrinApi.Models
{
    public class Member : Person
    {

        public Member(Guid id, string fullName, string email, string phoneNumber) : base(id, fullName, email, phoneNumber)
        {
            
            this. isActive = true;
            this.joinDate = DateOnly.FromDateTime(DateTime.Now);
            this.expiryDate = setExpiryDate(joinDate);
        }

        public DateOnly joinDate { get; private set; }
        public DateOnly expiryDate { get; set; }
        public bool isActive { get; set; }
        public uint ActiveBook { get; set; }

        public DateOnly setExpiryDate(DateOnly JoinDate)
        {
            return JoinDate.AddDays(180);
        }
    }
}
