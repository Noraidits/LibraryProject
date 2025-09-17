using System.Text.RegularExpressions;

namespace TamrinApi.Models
{
    public class Person
    {
        public Person(string fullName, string email, string phoneNumber)
        {
            CheckFullName(fullName);
            CheckEmail(email);
            CheckPhoneNumber(phoneNumber);


            fullName = fullName.ToLower();

            this.id = Guid.NewGuid();
            this.fullName = fullName;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }

        public Guid id { get; private init; }
        public string fullName { get;/*private*/  set; }
        public string email { get;/*private*/ set; }
        public string phoneNumber { get;/*private*/ set; }


        public void CheckFullName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName)) throw new Exception("Name is empty or null");

            var Reg = @"^[a-zA-Z\s'-]+$";
            if (!Regex.IsMatch(fullName, Reg)) { throw new Exception("pls ust use A-z"); }
        }

        public void CheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new Exception("Email is empty or null");

            var Reg = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; ;
            if (!Regex.IsMatch(email, Reg)) throw new Exception("pls enter the valid Email");
        }

        public void CheckPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) throw new Exception("Phone Number is Empty or Null");

            var Reg = @"^(\+98|0)\d{10}$";
            if (!Regex.IsMatch(phoneNumber, Reg)) throw new Exception("pls enter the valid phone number");
        }


        public void updateFullName(string fullName)
        {
            CheckFullName(fullName);
            this.fullName = fullName;
        }
        public void updatEmail(string Email)
        {
            CheckEmail(Email);
            this.email = Email;
        }
        public void updatPhoneNumber(string phoneNumber)
        {
            CheckPhoneNumber(phoneNumber);
            this.phoneNumber = phoneNumber;
        }
    }
}
