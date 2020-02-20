using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class VueCart
    {
        public int product { get; set; }
        public int quantity { get; set; }

        public int user_id { get; set; }
    }
}
