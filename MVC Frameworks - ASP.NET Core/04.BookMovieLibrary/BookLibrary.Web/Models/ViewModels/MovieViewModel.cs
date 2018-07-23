namespace BookLibrary.Web.Models.ViewModels
{
    using BookLibrary.Models;
    using System;
    using System.Linq;

    public class MovieViewModel
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public int DirectorId { get; set; }

        public string Director { get; set; }

        public string Status { get; set; }

        public static Func<Movie, MovieViewModel> FromMovie
        {
            get
            {
                return movie => new MovieViewModel()
                {
                    MovieId = movie.Id,
                    Title = movie.Title,
                    Director = movie.Director.Name,
                    DirectorId = movie.DirectorId,
                    Status = movie.Borrowers != null && movie.Borrowers.Any(x =>
                        (x.EndDate != null && x.EndDate > DateTime.Now) || x.EndDate == null)
                            ? "Borrowed"
                            : "At home"
                };
            }
        }
    }
}
