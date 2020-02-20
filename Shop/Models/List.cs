using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class List
    {
        public List()
        {
            ListProducts = new HashSet<ListProducts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }

        public Users User { get; set; }
        public ICollection<ListProducts> ListProducts { get; set; }
    }
}
