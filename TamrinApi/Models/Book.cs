using System.Text.RegularExpressions;

namespace TamrinApi.Models
{
    public class Book
    {
        public Book( string titel, string auther, string categoty, uint publishedYear, uint totalCopies)
        {
            if (nameChecker(titel))  throw new Exception("titel is not valid");
            if (nameChecker(auther)) throw new Exception("auther is not valid");
            if (nameChecker(categoty)) throw new Exception("categoty is not valid");
            if (publishedYear < 0 || publishedYear >= DateTime.Now.Year) throw new Exception("publish year is not valid");

            ID = Guid.NewGuid();
            this.title = titel;
            this.auther = auther;
            this.category = categoty;
            this.publishedYear = publishedYear;
            this.totalCopies = totalCopies;
            this.availabaleCopies = totalCopies;
        }

        public Guid ID  { get; private init; }
        public string title { get;private init; }
        public string auther { get; private init; }
        public string category { get; private init; }
        public uint publishedYear { get; private init; } 
        public uint totalCopies { get;/*private*/ set; }
        public uint availabaleCopies { get;/*private*/  set; }

        private bool nameChecker(string name)
        {
            string pattern = @"^[a-zA-Z\s\(\)\?\!]+$";
            return !Regex.IsMatch(name, pattern);
        }

        public void addTotaleCopies(uint aded)
        {
            this.totalCopies+= aded;
        }
        public void RemoveTotaleCopies(uint aded)
        {
            if (aded > this.totalCopies) throw new Exception("toatlCopies cant be smaller then 0");
            this.totalCopies -= aded;
        }
        public void addToAvailabalCopies()
        {
            this.availabaleCopies++;
        }
        public void removeFromAvailabalCopies()
        {
            if (this.availabaleCopies == 0) throw new Exception("availabal copies cant be smaller then 0");
            this.availabaleCopies--;
        }
    }
}
