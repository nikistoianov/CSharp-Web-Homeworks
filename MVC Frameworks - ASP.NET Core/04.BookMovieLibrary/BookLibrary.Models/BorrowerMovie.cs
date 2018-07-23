﻿using System;

namespace BookLibrary.Models
{
    public class BorrowerMovie
    {
        public int Id { get; set; }

        public int BorrowerId { get; set; }
        public Borrower Borrower { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
