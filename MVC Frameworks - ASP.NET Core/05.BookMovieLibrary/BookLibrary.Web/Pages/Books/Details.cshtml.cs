using System;
using BookLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BookLibrary.Web.Models.ViewModels;

namespace BookLibrary.Web.Pages.Books
{
    public class DetailsModel : PageModel
    {
        public DetailsModel(BookLibraryContext context)
        {
            this.Context = context;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        //public string Author { get; set; }
        public LinkViewModel Author { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public bool IsBorrowed { get; set; }

        public BookLibraryContext Context { get; set; }

        public IActionResult OnGet(int id)
        {
            var book = this.Context.Books
                .Include(b => b.Author)
                .Include(b => b.Borrowers)
                .FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return this.NotFound();
            }

            this.Id = book.Id;
            this.Title = book.Title;
            this.Description = book.Description;
            this.ImageUrl = book.CoverImage;
            this.Author = new LinkViewModel()
            {
                DisplayText = book.Author.Name,
                ControllerName = "Authors",
                ActionName = "Details",
                Id = book.AuthorId
            };
            this.IsBorrowed = book.Borrowers.Any(x => (x.EndDate != null && x.EndDate > DateTime.Now) || x.EndDate == null);

            return this.Page();
        }
    }
}