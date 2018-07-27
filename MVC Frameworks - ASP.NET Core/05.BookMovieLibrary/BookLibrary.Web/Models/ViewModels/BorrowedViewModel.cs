using BookLibrary.Models;
using System;
using System.Globalization;

namespace BookLibrary.Web.Models.ViewModels
{
    public class BorrowedViewModel
    {
        public string Name { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
        
        public static Func<BorrowerBook, BorrowedViewModel> FromBorrowedBooks
        {
            get
            {
                return order => new BorrowedViewModel()
                {
                    Name = order.Book.Title,
                    StartDate = order.StartDate.ToString("D", CultureInfo.InvariantCulture),
                    EndDate = order.EndDate == null ? "No date" : order.EndDate.Value.ToString("D", CultureInfo.InvariantCulture)
                };
            }
        }
    }
}
