using System.Text.RegularExpressions;

namespace TamrinApi.Models
{
    public class Book
    {
        public Book( string titel, string auther, string categoty, uint publishedYear, uint totalCopies, uint availabaleCopies)
        {
            if (nameChecker(titel))  throw new Exception("titel is not valid");
            if (nameChecker(auther)) throw new Exception("auther is not valid");
            if (nameChecker(categoty)) throw new Exception("categoty is not valid");
            if (publishedYear < 0 || publishedYear <= DateTime.Now.Year) throw new Exception("publish year is not valid");

            ID = Guid.NewGuid();
            this.titel = titel;
            this.auther = auther;
            this.categoty = categoty;
            this.publishedYear = publishedYear;
            this.totalCopies = totalCopies;
            this.availabaleCopies = totalCopies;
        }

        public Guid ID  { get; init; }
        public string titel { get; set; }
        public string auther { get; set; }
        public string categoty { get; set; }
        public uint publishedYear { get; set; }
        public uint totalCopies { get; set; }
        public uint availabaleCopies { get; set; }

        private bool nameChecker(string name)
        {
            string pattern = @"^[a-zA-Z\s\(\)\?\!]+$";
            return Regex.IsMatch(name, pattern);
        }




    }
}
