using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Web.Models.ViewModels
{
    public class BorrowViewModel
    {
        public BorrowViewModel()
        {
            this.Borrowers = new List<SelectListItem>();
        }

        [Required(ErrorMessage = "You have to specify a borrower.")]
        [Display(Name = "Borrower")]
        public int BorrowerId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [BindNever]
        public IEnumerable<SelectListItem> Borrowers { get; set; }
    }
}
