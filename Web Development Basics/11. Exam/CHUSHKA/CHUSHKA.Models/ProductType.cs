using System.Collections.Generic;

namespace CHUSHKA.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductType
    {
        public ProductType()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
