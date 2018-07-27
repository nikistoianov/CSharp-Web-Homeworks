using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Web.Models.BindingModels
{
    public class BorrowerBindingModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
