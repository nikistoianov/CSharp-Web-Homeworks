using System.Collections.Generic;

namespace BookLibrary.Web.Models.ViewModels
{
    public class DirectorViewModel
    {
        public DirectorViewModel()
        {
            this.Movies = new List<MovieViewModel>();
        }

        public string Name { get; set; }

        public List<MovieViewModel> Movies { get; set; }
    }
}
