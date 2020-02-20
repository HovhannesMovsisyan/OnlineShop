using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class Users
    {
        public Users()
        {
            Cart = new HashSet<Cart>();
            List = new HashSet<List>();
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }

        public ICollection<Cart> Cart { get; set; }
        public ICollection<List> List { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
