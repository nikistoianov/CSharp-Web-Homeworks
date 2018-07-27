namespace BookLibrary.Web.Models.BindingModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using Attributes;

    public class BorrowBindingModel
    {
        public BorrowBindingModel()
        {
            this.Borrowers = new List<SelectListItem>();
            this.StartDate = DateTime.Now;
        }

        [Required(ErrorMessage = "You have to specify a borrower.")]
        [Display(Name = "Borrower")]
        public int BorrowerId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DateAfter("StartDate", "The end date must be after the start date.")]
        public DateTime? EndDate { get; set; }

        [BindNever]
        public IEnumerable<SelectListItem> Borrowers { get; set; }


    }
}
