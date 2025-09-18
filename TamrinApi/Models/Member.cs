    using System.Globalization;

namespace TamrinApi.Models
{
    public class Member : Person
    {
        private List<Borrowing> _Borrows= new List<Borrowing>();

        private Member() : base("", "", "") { }
        public Member(string fullName, string email, string phoneNumber) : base(fullName, email, phoneNumber)
        { 

            this.isActive = true;
            this.joinDate = DateOnly.FromDateTime(DateTime.Now);
            this.expiryDate = joinDate.AddDays(180);
        }

        public DateOnly joinDate { get; private init; }
        public DateOnly expiryDate { get; /*private */set; }
        public bool isActive { get;private set;}
        public uint ActiveBook { get;/*private*/ set; }
        public IEnumerable<Borrowing> Borrows { get => _Borrows.AsReadOnly(); }

        public void addTOExpiryDate(short howManyDayYouLikeToAdd)
        {   if (howManyDayYouLikeToAdd < 1) throw new Exception("its shiud be biger then 0");
            if (howManyDayYouLikeToAdd > 366) throw new Exception("you cant update your expiery more then one year");
            if (isActive)
                this.expiryDate.AddDays((howManyDayYouLikeToAdd));
            else this.expiryDate=DateOnly.FromDateTime(DateTime.Now).AddDays(howManyDayYouLikeToAdd);
        }
        public void changeIsActive(bool isActive) { this.isActive = isActive; }
        //public void addActiveBook() {
        //    this.ActiveBook++;
        //}
        //public void removeActiveBook()
        //{   if (ActiveBook == 0) throw new Exception("Active book cant be negetive");
        //    this.ActiveBook--;
        //}
        public void ActiveBooks()
        {
            this.ActiveBook =(uint) _Borrows.Count();
        }

        public void AddBorrow(Borrowing borow)
        {
            if (_Borrows.Count() > 5) throw new Exception("you can have more then 5 book");
                _Borrows.Add(borow);
            ActiveBooks();
        }

        public void RemoveBorrow(Guid BorrowId)
        {
            var borrow = _Borrows.FirstOrDefault(x => x.id == BorrowId);

            if (borrow is not null)
                _Borrows.Remove(borrow);
            ActiveBooks();
        }

    }
}
