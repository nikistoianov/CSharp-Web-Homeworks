using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Data;
using BookLibrary.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Web.Controllers
{
    public class DirectorsController : Controller
    {
        private BookLibraryContext context;

        public DirectorsController(BookLibraryContext context)
        {
            this.context = context;
        }

        public IActionResult Details(int id)
        {
            var director = this.context.Directors
                .Where(x => x.Id == id)
                .Include(x => x.Movies)
                .ThenInclude(x => x.Borrowers)
                .FirstOrDefault();

            if (director == null)
            {
                return this.NotFound();
            }

            var model = new DirectorViewModel()
            {
                Name = director.Name,
                Movies = director.Movies.Select(MovieViewModel.FromMovie).ToList()
            };

            return View(model);
        }
    }
}