namespace BookLibrary.Web.Models.ViewModels
{
    using BookLibrary.Models;
    using System;
    using System.Linq;

    public class MoviesDetailsViewModel
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public bool IsBorrowed { get; set; }

        public static Func<Movie, MoviesDetailsViewModel> FromMovie
        {
            get
            {
                return movie => new MoviesDetailsViewModel()
                {
                    MovieId = movie.Id,
                    Title = movie.Title,
                    Director = movie.Director.Name,
                    ImageUrl = movie.PosterImage,
                    Description = movie.Description,
                    IsBorrowed = movie.Borrowers != null && movie.Borrowers.Any(x =>
                        (x.EndDate != null && x.EndDate > DateTime.Now) || x.EndDate == null)
                };
            }
        }
    }
}
