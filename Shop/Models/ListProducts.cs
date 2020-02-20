using System;
using System.Collections.Generic;
namespace Shop.Models
{
    public partial class ListProducts
    {
        public int ProductId { get; set; }
        public int ListId { get; set; }
        public string Description { get; set; }

        public List List { get; set; }
        public Products Product { get; set; }
    }
}
