using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Data;
using BookLibrary.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Web.Pages.Books
{
    public class HistoryModel : PageModel
    {
        private readonly BookLibraryContext db;

        public HistoryModel(BookLibraryContext db)
        {
            this.db = db;
        }

        public string Title { get; set; }

        public List<BorrowedViewModel> Orders { get; set; }

        public IActionResult OnGet(int id)
        {
            var book = this.db.Books.Find(id);

            if (book == null)
            {
                return this.NotFound();
            }

            var orders = this.db.BorrowedBooks
                .Where(x => x.BookId == id)
                .Include(x => x.Book)
                .Select(BorrowedViewModel.FromBorrowedBooks)
                .ToList();

            this.Title = book.Title;
            this.Orders = orders;

            return this.Page();
        }
    }
}