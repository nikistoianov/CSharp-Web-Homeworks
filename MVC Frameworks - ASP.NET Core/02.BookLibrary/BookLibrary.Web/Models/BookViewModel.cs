namespace BookLibrary.Web.Models
{
    using System;
    using System.Linq;
    using BookLibrary.Models;

    public class BookViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string Author { get; set; }

        public string Status { get; set; }

        public static Func<Book, BookViewModel> FromBook
        {
            get
            {
                return book => new BookViewModel()
                {
                    BookId = book.Id,
                    Title = book.Title,
                    Author = book.Author.Name,
                    AuthorId = book.Author.Id,
                    Status = book.Borrowers != null && book.Borrowers.Any(x =>
                        (x.EndDate != null && x.EndDate > DateTime.Now) || x.EndDate == null)
                            ? "Borrowed"
                            : "At home"
                };

            }
        }
    }
}
