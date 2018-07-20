namespace CHUSHKA.App.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using CHUSHKA.Models;
    public class ProductBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public int ProductTypeId { get; set; }

    }
}
