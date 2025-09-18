namespace TamrinApi.Models
{
    public class Borrowing
    {
        public Borrowing() { }
        public Borrowing(Guid bookid, Guid memberid)
        {
            this.id = Guid.NewGuid();
            this.bookid = bookid;
            this.memberid = memberid;
            this.borrowDate = DateOnly.FromDateTime(DateTime.Now);
            this.shouldReturnDate = ShouldReturnDate(borrowDate);
        }

        public Guid id { get; private init; }
        public Guid bookid { get;private init; }
        public Guid memberid { get;private init; }
        public DateOnly borrowDate { get;private init;}
        public DateOnly shouldReturnDate { get; private init; }
        public DateOnly returnDate { get;private set; }

        public DateOnly MaxBrrowingDate => this.borrowDate.AddDays(14);

        public DateOnly ShouldReturnDate(DateOnly boorrowDate)
        {
            return boorrowDate.AddDays(14);
        }
        public void returnDateSeter()
        {
            this.returnDate =DateOnly.FromDateTime(DateTime.Now);
        }
        
    }
}
