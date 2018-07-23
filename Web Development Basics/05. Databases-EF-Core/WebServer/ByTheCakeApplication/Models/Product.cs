﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HTTPServer.ByTheCakeApplication.Models
{
    public class Product
    {
        public Product()
        {
            this.Orders = new List<ProductOrder>();
        }

        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [StringLength(2048, MinimumLength = 0)]
        public string ImageUrl { get; set; }

        public ICollection<ProductOrder> Orders { get; set; }
    }
}
