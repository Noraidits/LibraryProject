using System.Text.RegularExpressions;

namespace TamrinApi.Models
{
    public class Person
    {
        public Person( string fullName, string email, string phoneNumber)
        {
            //CheckFullName(fullName);
            //CheckEmail(email);
            //CheckPhoneNumber(phoneNumber);

            this.id = Guid.NewGuid();
            this.fullName = fullName;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }

        public Guid id { get; protected set; }
        public string fullName { get; set; }
        public string email { get; set; } 
        public string phoneNumber { get; set; }


        public void CheckFullName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName)) throw new Exception("Name is empty or null");

            var Reg = @"^[a-z ,.'-]+$";
            if (Regex.IsMatch(fullName, Reg)) { throw new Exception("pls ust use A-z"); }
        }

        public void CheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new Exception("Email is empty or null");

            var Reg = "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$\r\n";
            if (Regex.IsMatch(email, Reg)) throw new Exception("pls enter the valid Email");
        }

        public void CheckPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) throw new Exception("Phone Number is Empty or Null");

            var Reg = "^(\\+98|0)\\d{9}$";
            if (Regex.IsMatch(phoneNumber,Reg)) throw new Exception("pls enter the valid phone number") ;
        }
    }
}
