using BookLibrary.Data;
using BookLibrary.Models;
using BookLibrary.Web.Attributes;
using BookLibrary.Web.Models.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace BookLibrary.Web.Pages.Books
{
    [Authorization]
    public class BorrowModel : PageModel
    {
        public BorrowModel(BookLibraryContext context)
        {
            this.Context = context;
            this.BorrowForm = new BorrowBindingModel(); 
        }

        public BookLibraryContext Context { get; private set; }

        [BindProperty]
        public BorrowBindingModel BorrowForm { get; set; }

        public void OnGet()
        {
            this.BorrowForm.Borrowers = this.Context.Borrowers
                .Select(b => new SelectListItem()
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                })
                .ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var borrower = this.Context.Borrowers.Find(this.BorrowForm.BorrowerId);
            int bookId = Convert.ToInt32(this.RouteData.Values["id"]);
            var book = this.Context.Books.Find(bookId);
            if (borrower == null || book == null)
            {
                return Page();
            }

            var borrowedBook = new BorrowerBook()
            {
                BookId = book.Id,
                BorrowerId = borrower.Id,
                StartDate = this.BorrowForm.StartDate,
                EndDate = this.BorrowForm.EndDate
            };

            book.Status = Book.STATUS_BORROWED;

            this.Context.BorrowedBooks.Add(borrowedBook);
            this.Context.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}