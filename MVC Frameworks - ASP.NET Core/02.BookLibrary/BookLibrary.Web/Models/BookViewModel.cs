namespace BookLibrary.Web.Models
{
    using System;
    using BookLibrary.Models;

    public class BookViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string Author { get; set; }

        public static Func<Book, BookViewModel> FromBook
        {
            get
            {
                return book => new BookViewModel()
                {
                    BookId = book.Id,
                    Title = book.Title,
                    Author = book.Author.Name,
                    AuthorId = book.Author.Id
                };
            }
        }
    }
}
