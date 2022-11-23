using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } 
        public DateTime ReleaseDate { get; set; }
        public ICollection<Comments> Comments { get; set;}
    }
}
