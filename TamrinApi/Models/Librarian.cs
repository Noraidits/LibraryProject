using Facebook.Infrastructure.Helper;
using System.Text.RegularExpressions;

namespace TamrinApi.Models
{
    public class Librarian : Person
    {
        private string _password = "";
        public Librarian( string fullName, string email, string phoneNumber, string userName, string Password) : base( fullName, email, phoneNumber)
        {
            CheckUserName(userName);
            CheckinputPass(Password);

            id = Guid.NewGuid();
            this.id = id;

            this.userName = userName;
            this.Password = Password;
        }

        public string userName { get;private set; }
        public string Password { 
            set
            {
                _password = HashHelper.ComputeSha256Hash(value);
            }
        }

        public void CheckUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName)) throw new Exception("UserName can't be null or empty");

            var Reg = "^[a-zA-Z0-9]+$";
            if (!Regex.IsMatch(userName, Reg)) throw new Exception("Use the valid Username(A-z,_,0-9)");
        }
        
        public void CheckinputPass(string inputPass)
        {
            if (string.IsNullOrEmpty(inputPass)) throw new Exception("your password can't be null or empty");
        }

        public bool HashPassCheck(string password)
        {
            return HashHelper.VerifySha256Hash(password, _password);
        }
    }
}
