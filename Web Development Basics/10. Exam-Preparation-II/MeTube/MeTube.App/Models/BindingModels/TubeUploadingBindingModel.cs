namespace MeTube.App.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class TubeUploadingBindingModel
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string YouTubeLink { get; set; }

        public string Description { get; set; }
    }
}
