using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class ProductsPhotos
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string Photo { get; set; }

        public Products Product { get; set; }
    }
}
