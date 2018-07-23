namespace BookLibrary.Models
{
    using System.Collections.Generic;

    public class Borrower
    {
        public Borrower()
        {
            this.BorrowedBooks = new HashSet<BorrowerBook>();
            this.BorrowedMovies = new HashSet<BorrowerMovie>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<BorrowerBook> BorrowedBooks { get; set; }

        public ICollection<BorrowerMovie> BorrowedMovies { get; set; }
    }
}
