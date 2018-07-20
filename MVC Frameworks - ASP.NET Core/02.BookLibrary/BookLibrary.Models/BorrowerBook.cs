namespace BookLibrary.Models
{
    using System;

    public class BorrowerBook
    {
        public int BorrowerId { get; set; }

        public Borrower Borrower { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
