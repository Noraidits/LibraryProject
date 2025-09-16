namespace TamrinApi.Models
{
    public class Borrowing
    {
        public Borrowing(Guid bookid, Guid memberid)
        {
            this.id = Guid.NewGuid();
            this.bookid = bookid;
            this.memberid = memberid;
            this.borrowDate = DateOnly.FromDateTime(DateTime.Now);
            this.shouldReturnDate = ShouldReturnDate(borrowDate);
        }

        public Guid id { get; private set; }
        public Guid bookid { get; init; }
        public Guid memberid { get; init; }
        public DateOnly borrowDate { get; init; }
        public DateOnly shouldReturnDate { get; init; }
        public DateOnly returnDate { get; set; }

        public DateOnly MaxBrrowingDate => this.borrowDate.AddDays(14);

        public DateOnly ShouldReturnDate(DateOnly boorrowDate)
        {
            return boorrowDate.AddDays(14);
        }
    }
}
