using BookLibrary.Data;
using BookLibrary.Models;
using BookLibrary.Web.Models.BindingModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Web.Controllers
{
    public class BorrowersController : Controller
    {
        private BookLibraryContext context;

        public BorrowersController(BookLibraryContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BorrowerBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            var borrower = new Borrower()
            {
                Name = model.Name,
                Address = model.Address
            };

            this.context.Borrowers.Add(borrower);
            this.context.SaveChanges();

            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}
