using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Data;
using BookLibrary.Web.Models;
using BookLibrary.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Web.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        public DetailsModel(BookLibraryContext context)
        {
            this.Context = context;
        }

        public string Name { get; set; }

        public List<BookViewModel> Books { get; set; }

        public BookLibraryContext Context { get; set; }

        public IActionResult OnGet(int id)
        {
            var author = this.Context.Authors
                .Where(x => x.Id == id)
                .Include(x => x.Books)
                .FirstOrDefault();

            if (author == null)
            {
                return this.NotFound();
            }

            this.Name = author.Name;
            this.Books = author.Books.Select(BookViewModel.FromBook).ToList();

            return this.Page();
        }
    }
}