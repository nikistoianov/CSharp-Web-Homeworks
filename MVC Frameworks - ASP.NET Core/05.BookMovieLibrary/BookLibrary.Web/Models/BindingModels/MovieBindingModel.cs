namespace BookLibrary.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class MovieBindingModel
    {
        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        [Url, Display(Name = "Cover image url")]
        public string ImageUrl { get; set; }
    }
}
