using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class Products
    {
        public Products()
        {
            Cart = new HashSet<Cart>();
            ListProducts = new HashSet<ListProducts>();
            ProductsPhotos = new HashSet<ProductsPhotos>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? Count { get; set; }
        public int? UserId { get; set; }

        public Users User { get; set; }
        public ICollection<Cart> Cart { get; set; }
        public ICollection<ListProducts> ListProducts { get; set; }
        public ICollection<ProductsPhotos> ProductsPhotos { get; set; }
    }
}
