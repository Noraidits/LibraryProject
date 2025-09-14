using System.Globalization;

namespace TamrinApi.Models
{
    public class Member : Person
    {
        

        public Member(string fullName, string email, string phoneNumber) : base(fullName, email, phoneNumber)
        { 

            this.isActive = true;
            this.joinDate = DateOnly.FromDateTime(DateTime.Now);
            this.expiryDate = joinDate.AddDays(180);
        }

        public DateOnly joinDate { get; private set; }
        public DateOnly expiryDate { get; set; }
        public bool isActive { get; set; }
        public uint ActiveBook { get; set; }


    }
}
