namespace MyTube.App.Models.ViewModels
{
    using System;
    using MyTube.Models;

    public class TubeIndexViewModel
    {
        public string YouTubeId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public static Func<Tube, TubeIndexViewModel> FromTube =>
            tube => new TubeIndexViewModel()
            {
                YouTubeId = tube.YouTubeId,
                Author = tube.Author,
                Title = tube.Title
            };
    }
}
