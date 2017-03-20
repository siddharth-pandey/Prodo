using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodo.API.Models
{
    public class Product
    {
        public Product()
        {
            Id = -1;
        }

        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public double Cost { get; set; }

        public bool OutOfStock { get; set; }
    }
}