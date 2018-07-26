using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Data;
using BookLibrary.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Web.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(BookLibraryContext context)
        {
            this.Context = context;
        }

        public BookLibraryContext Context { get; set; }

        public IEnumerable<BookViewModel> Books { get; set; }
        public IEnumerable<MovieViewModel> Movies { get; set; }

        public void OnGet()
        {
            this.Books = this.Context.Books
                .Include(b => b.Author)
                .Include(b => b.Borrowers)
                .OrderBy(b => b.Title)
                .Select(BookViewModel.FromBook)
                .ToList();

            this.Movies = this.Context.Movies
                .Include(b => b.Director)
                .Include(b => b.Borrowers)
                .OrderBy(b => b.Title)
                .Select(MovieViewModel.FromMovie)
                .ToList();
        }
    }
}
