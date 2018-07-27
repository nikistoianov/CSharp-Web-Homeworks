namespace BookLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public const string STATUS_BORROWED = "Borrowed";
        public const string STATUS_ATHOME = "At home";

        public Book()
        {
            this.Borrowers = new HashSet<BorrowerBook>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string CoverImage { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [Required]
        public string Status { get; set; }

        public ICollection<BorrowerBook> Borrowers { get; set; }
    }
}
