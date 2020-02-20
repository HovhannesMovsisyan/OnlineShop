using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class Cart
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }

        public Products Product { get; set; }
        public Users User { get; set; }
    }
}
