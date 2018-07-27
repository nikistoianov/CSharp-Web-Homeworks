using BookLibrary.Data;
using BookLibrary.Models;
using BookLibrary.Web.Attributes;
using BookLibrary.Web.Models.BindingModels;
using BookLibrary.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookLibrary.Web.Controllers
{
    public class MoviesController : Controller
    {
        private BookLibraryContext context;

        public MoviesController(BookLibraryContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Authorization]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MovieBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            var director = CreateOrUpdateDirector(model);
            Movie movie = CreateMovie(model, director);

            return RedirectToAction("Details", new { id = movie.Id });
        }

        public IActionResult Details(int id)
        {
            var movie = this.context.Movies
                .Include(x => x.Director)
                .Include(x => x.Borrowers)
                .FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return this.NotFound();
            }

            var model = new[] { movie }
                .Select(MoviesDetailsViewModel.FromMovie)
                .First();

            return View(model);
        }

        [HttpGet]
        public IActionResult Borrow(int id)
        {
            if (id == 0)
            {
                return this.NotFound();
            }

            var movies = this.context.Movies.Find(id);
            if (movies == null)
            {
                return this.NotFound();
            }

            var model = new BorrowBindingModel()
            {
                Borrowers = this.context.Borrowers
                    .Select(b => new SelectListItem()
                    {
                        Text = b.Name,
                        Value = b.Id.ToString()
                    })
                .ToList(),
                StartDate = DateTime.Now
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Borrow(BorrowBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            var borrower = this.context.Borrowers.Find(model.BorrowerId);
            int movieId = Convert.ToInt32(this.RouteData.Values["id"]);
            var movie = this.context.Movies.Find(movieId);
            if (borrower == null || movie == null)
            {
                return View();
            }

            var borrowedMovie = new BorrowerMovie()
            {
                MovieId = movie.Id,
                BorrowerId = borrower.Id,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };

            this.context.BorrowedMovies.Add(borrowedMovie);
            this.context.SaveChanges();

            return RedirectToPage("/Index");
        }

        private Director CreateOrUpdateDirector(MovieBindingModel model)
        {
            var director = this.context.Directors
                .FirstOrDefault(a => a.Name == model.Director);

            if (director == null)
            {
                director = new Director()
                {
                    Name = model.Director
                };

                this.context.Directors.Add(director);
                this.context.SaveChanges();
            }

            return director;
        }

        private Movie CreateMovie(MovieBindingModel model, Director director)
        {
            var movie = new Movie()
            {
                Title = model.Title,
                Description = model.Description,
                PosterImage = model.ImageUrl,
                DirectorId = director.Id
            };

            this.context.Movies.Add(movie);
            this.context.SaveChanges();
            return movie;
        }

    }
}